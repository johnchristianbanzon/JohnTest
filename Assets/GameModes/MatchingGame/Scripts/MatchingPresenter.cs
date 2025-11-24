using System;
using System.Collections.Generic;
using System.Diagnostics;

public class MatchingPresenter : BasePresenter<MatchingModel, MatchingView>
{
    private IMatchingControllerResource _matchingGameController;

    public override void Initialize(MatchingModel model, MatchingView view)
    {
        base.Initialize(model, view);
        Model.OnCompleteGame = View.ShowResultScreen;
        Model.OnUpdateScore = UpdateScore;
    }

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
            View.OnMatchCardSpawn = Model.AddMatchCard;
            View.SetupBoard(symbolData, Model.TapMatchCard, matchingConfig);
            Model.StartGame();
        }
    }

    public void OverrideBoardFromSaveData(MatchingConfigSO savedMatchConfig, List<MatchSaveStateData> matchSaveStateOverride)
    {
        Model.GetSymbolsFromSavedMatchData(savedMatchConfig,matchSaveStateOverride, PopulateView);
        void PopulateView(List<SymbolData> symbolData)
        {
            UnityEngine.Debug.Log("GOT SUCCESS!!");
            View.OnMatchCardSpawn = Model.AddMatchCard;
            View.ContinueBoard(matchSaveStateOverride, Model.TapMatchCard, savedMatchConfig);
            Model.StartGame();
        }
    }


    public void UpdateScore(int score)
    {
        View.UpdateScore(score);
    }
   
}
