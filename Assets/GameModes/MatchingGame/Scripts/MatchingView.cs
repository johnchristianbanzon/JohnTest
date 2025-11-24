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

    public void Inject(IMatchingControllerResource matchingGameController)
    {
        _matchingGameController = matchingGameController;
    }

    public void SetupBoard(List<SymbolData> symbolData, Action<MatchCard> OnFlip, MatchingConfigSO catchConfig)
    {
        _gridLayoutGroup.enabled = true;
        _gridLayoutGroup.constraintCount = catchConfig.GameboardSize.x;
        for (int i = 0; i < symbolData.Count; i++)
        {
            var matchCard = Instantiate(_matchCard, _gridLayoutGroup.transform);
            matchCard.InitializeCard(symbolData[i], OnFlip);
            matchCard.SpawnAnimation(0.05f * i);
        }
    }

    public void BoardReady()
    {
        _gridLayoutGroup.enabled = false;
    }
}