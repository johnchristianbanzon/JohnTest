using System;

public class MatchingPresenter : BasePresenter<MatchingModel, MatchingView>
{
    public void SetupBoard(MatchingConfig matchingConfig)
    {
        View.SetupBoard(matchingConfig.GameboardSize.x, matchingConfig.GameboardSize.y);
    }
}
