using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchingView : BaseView
{
    [SerializeField]
    private MatchCard _matchCard;
    [SerializeField]
    private GridLayoutGroup _gridLayoutGroup;
    private IMatchingControllerResource _matchingGameController;
    [SerializeField]
    private Text _score;
    [SerializeField]
    private Text _lives;
    public Action<MatchCard> OnMatchCardSpawn;
    [SerializeField]
    private GameObject _resultScreen;
    [SerializeField]
    private Text _resultText;
    public void Inject(IMatchingControllerResource matchingGameController)
    {
        _matchingGameController = matchingGameController;
    }

    public void SetupBoard(List<SymbolData> symbolData, Action<MatchCard> OnFlip, MatchingConfigSO catchConfig)
    {
        _gridLayoutGroup.enabled = true;
        _gridLayoutGroup.constraintCount = catchConfig.GameboardSize.x > catchConfig.GameboardSize.y ? catchConfig.GameboardSize.x : catchConfig.GameboardSize.y;
        for (int i = 0; i < symbolData.Count; i++)
        {
            var matchCard = Instantiate(_matchCard, _gridLayoutGroup.transform);
            matchCard.InitializeCard(symbolData[i], OnFlip);
            matchCard.SpawnAnimation(0.05f * i);
            OnMatchCardSpawn?.Invoke(matchCard);
        }
    }

    public void ContinueBoard(List<MatchSaveStateData> matchSaveData, Action<MatchCard> OnFlip, MatchingConfigSO catchConfig)
    {
        _gridLayoutGroup.enabled = true;
        Debug.Log("catchConfig.GameboardSize.x :" + catchConfig.GameboardSize.x + " / " + catchConfig.GameboardSize.y);
        _gridLayoutGroup.constraintCount = catchConfig.GameboardSize.x > catchConfig.GameboardSize.y ? catchConfig.GameboardSize.x : catchConfig.GameboardSize.y;
        for (int i = 0; i < matchSaveData.Count; i++)
        {
            var matchCard = Instantiate(_matchCard, _gridLayoutGroup.transform);
            matchCard.InitializeCard(matchSaveData[i].GetSymbolData(), OnFlip);
            matchCard.SpawnAnimation(0.05f * i);
            OnMatchCardSpawn?.Invoke(matchCard);
            matchCard.transform.SetSiblingIndex(matchSaveData[i].Position);
            if (matchSaveData[i].IsFaceUp)
            {
                matchCard.Flip(true, false);
            }
            if (matchSaveData[i].IsMatched)
            {
                matchCard.IsMatched = true;
                matchCard.PopOut();
            }
        }
    }

    public void BoardReady()
    {
        _gridLayoutGroup.enabled = false;
    }

    public void UpdateScore(int score)
    {
        _score.text = "SCORE: "+score.ToString();
    }

    public void ShowResultScreen(bool win)
    {
        _resultScreen.gameObject.SetActive(true);
        _resultText.text = win ? "WIN": "LOSE";
    }
    
}