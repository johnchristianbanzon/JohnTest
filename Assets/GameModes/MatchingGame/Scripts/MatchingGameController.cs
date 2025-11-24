
using System.Collections.Generic;
using UnityEngine;

public class MatchingGameController : GameController, IMatchingControllerResource
{
    [SerializeField]
    private MatchingView _matchingView;
    [SerializeField]
    private MatchingConfigSO _matchingConfig;
    [SerializeField]
    private MatchingSymbolContainerSO _symbolContainer;
    private MatchingPresenter _matchingPresenter;
    private List<SymbolData> _uniqueSymbolData = new List<SymbolData>();

    public SymbolData GetRandomMatchingSymbol()
    {
        if(_uniqueSymbolData.Count == 0)
        {
            for (int i = 0; i < _symbolContainer.SymbolData.Length; i++)
            {
                _uniqueSymbolData.Add(_symbolContainer.SymbolData[i]);
            }
        }
        var randomPoint = Random.Range(0, _uniqueSymbolData.Count);
        var symbolData = _uniqueSymbolData[randomPoint];
        _uniqueSymbolData.RemoveAt(randomPoint);

        return symbolData;
    }

    public override void Setup()
    {
        _matchingPresenter = new MatchingPresenter();
        _matchingPresenter.Initialize(new MatchingModel(), _matchingView);
        _matchingPresenter.Inject(this);

    }

    public override void StartGame()
    {
        _matchingPresenter.SetupBoard(_matchingConfig);
    }
}