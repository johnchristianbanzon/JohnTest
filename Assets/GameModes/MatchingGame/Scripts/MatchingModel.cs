using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;

public class MatchingModel : BaseModel
{
    private List<SymbolData> _matchSymbolsList = new List<SymbolData>();
    private List<MatchCard> _matchCards = new List<MatchCard>();
    private IMatchingControllerResource _matchingGameController;
    private ISaveManager _saveManager;
    private MatchingConfigSO _matchConfig;
    private List<MatchingGroupCheck> _matchingGroupChecks = new List<MatchingGroupCheck>();
    private int _score;
    private bool _streakActive;
    private int _lives;
    public Action<int> OnUpdateScore;
    public Action<bool> OnCompleteGame;

    public override void Initialize()
    {
        base.Initialize();
        _saveManager = DependencyResolver.Container.Resolve<ISaveManager>();
    }

    public void AddMatchCard(MatchCard matchCard)
    {
        _matchCards.Add(matchCard);
    }

    public void Inject(IMatchingControllerResource matchingGameController)
    {
        _matchingGameController = matchingGameController;
    }

    public void GetSymbolsFromSavedMatchData(MatchingConfigSO matchConfig ,List<MatchSaveStateData> matchSaveStateOverride, Action<List<SymbolData>> OnCompletePopulateBoard)
    {
        _matchConfig = matchConfig;
        UnityEngine.Debug.Log("HERE 1 " + matchSaveStateOverride.Count);
        for (int i = 0; i < matchSaveStateOverride.Count; i++)
        {
            var symbolData = _matchingGameController.GetSymbolDataFromId(matchSaveStateOverride[i].CardId);
            matchSaveStateOverride[i].SetSymbolData(symbolData);
            if (i == matchSaveStateOverride.Count - 1)
            {
                OnCompletePopulateBoard?.Invoke(_matchSymbolsList);
            }
        }
      
    }

    public void GetMatchBoard(MatchingConfigSO matchConfig, Action<List<SymbolData>> OnCompletePopulateBoard)
    {
        _matchConfig = matchConfig;
     
        int totalCards = matchConfig.GameboardSize.x * matchConfig.GameboardSize.y;
        int pairCount = totalCards / _matchConfig.MatchConditionAmount;

        for (int i = 0; i < pairCount; i++)
        {
            var randomMatchSymbol = _matchingGameController.GetRandomMatchingSymbol();
            for (int j = 0; j < _matchConfig.MatchConditionAmount; j++)
            {
                _matchSymbolsList.Add(randomMatchSymbol);
            }

            if (i == pairCount - 1)
            {
                _matchSymbolsList = _matchSymbolsList.OrderBy(i => UnityEngine.Random.value).ToList();
                OnCompletePopulateBoard?.Invoke(_matchSymbolsList);
            }
        }

    }

    public void StartGame()
    {
        _score = 0;
        OnUpdateScore?.Invoke(_score);
    }

    private void AddScore()
    {
        _score += 1;
        OnUpdateScore?.Invoke(_score);
    }

    private void CheckGameEnd()
    {
        var allMatched = _matchCards.All(match=> match.IsMatched);
        if (allMatched)
        {
            //END GAME
            OnCompleteGame?.Invoke(true);
        }
    }

    public void TapMatchCard(MatchCard card)
    {
        var matchingGroupCheck = GetMatchingGroupCheck();
        matchingGroupCheck.AddSymbol(card);
        SaveData();

    }

    public void SaveData()
    {
        var save = new MatchSaveStateDataList();

        foreach (var card in _matchCards)
        {
            save.Cards.Add(new MatchSaveStateData
            {
                CardId = card.SymbolData.Id,
                Position = card.transform.GetSiblingIndex(),
                IsMatched = card.IsMatched,
                IsFaceUp = card.IsFaceUp
            }) ; 
        }
        _saveManager.SaveMatchingSaveData(save);
    }

    private void MatchGroupComplete(MatchingGroupCheck matchGroup)
    {
        if (matchGroup.IsGroupCorrect())
        {
            matchGroup.MatchSuccess();
            AddScore();
        }
        else
        {
            matchGroup.ResetMatch();
        }
        CheckGameEnd();
    }


    private MatchingGroupCheck GetMatchingGroupCheck()
    {
        for (int i = 0; i < _matchingGroupChecks.Count; i++)
        {
            if (_matchingGroupChecks[i].IsGroupFull()==false)
            {
                return _matchingGroupChecks[i];
            }
        }

        var matchGroup = new MatchingGroupCheck();
        matchGroup.Initialize(_matchConfig.MatchConditionAmount, MatchGroupComplete);
        _matchingGroupChecks.Add(matchGroup);
        return matchGroup;
    }
}