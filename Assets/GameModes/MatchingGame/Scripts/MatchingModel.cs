using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MatchingModel : BaseModel
{
    private List<SymbolData> MatchSymbolsList = new List<SymbolData>();
    private IMatchingControllerResource _matchingGameController;
    private MatchingConfigSO _matchConfig;
    private List<MatchingGroupCheck> _matchingGroupChecks = new List<MatchingGroupCheck>();

    public void Inject(IMatchingControllerResource matchingGameController)
    {

        _matchingGameController = matchingGameController;
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
                MatchSymbolsList.Add(randomMatchSymbol);
            }

            if (i == pairCount - 1)
            {
                MatchSymbolsList = MatchSymbolsList.OrderBy(i => UnityEngine.Random.value).ToList();
                OnCompletePopulateBoard?.Invoke(MatchSymbolsList);
            }
        }

    }

    public void TapMatchCard(MatchCard card)
    {
        var matchingGroupCheck = GetMatchingGroupCheck();
        matchingGroupCheck.AddSymbol(card);

    }

    private void MatchGroupComplete(MatchingGroupCheck matchGroup)
    {
        if (matchGroup.IsGroupCorrect())
        {
            matchGroup.MatchSuccess();
        }
        else
        {
            matchGroup.ResetMatch();
        }
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