
using UnityEngine;

public class MatchingGameController : GameController
{
    [SerializeField]
    private MatchingView _matchingView;
    [SerializeField]
    private MatchingConfig _matchingConfig;
    private MatchingPresenter _matchingPresenter;

    public override void Setup()
    {
        _matchingPresenter = new MatchingPresenter();
        _matchingPresenter.Initialize(new MatchingModel(), _matchingView);

    }

    public override void StartGame()
    {
        _matchingPresenter.SetupBoard(_matchingConfig);
    }
}