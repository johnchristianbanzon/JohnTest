using System;
using System.Collections.Generic;

public class MatchingPresenter : BasePresenter<MatchingModel, MatchingView>
{
    private IMatchingControllerResource _matchingGameController;

    public void Inject(IMatchingControllerResource matchingGameController)
    {
        _matchingGameController = matchingGameController;
        View.Inject(matchingGameController);
        Model.Inject(_matchingGameController);
    }

    public void SetupBoard(MatchingConfigSO matchingConfig)
    {
        Model.GetMatchBoard(matchingConfig, PopulateView);


        void PopulateView(List<SymbolData> symbolData)
        {
            View.SetupBoard(symbolData, Model.TapMatchCard, matchingConfig);
        }
    }

   
}
