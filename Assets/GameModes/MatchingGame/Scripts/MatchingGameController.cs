
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MatchingGameController : GameController, IMatchingControllerResource
{
    [SerializeField]
    private MatchingView _matchingView;
    [SerializeField]
    private MatchingSymbolContainerSO _symbolContainer;
    private MatchingPresenter _matchingPresenter;
    private List<SymbolData> _uniqueSymbolData = new List<SymbolData>();
    private ISaveManager _saveManager;
    private IGameManager _gameManager;


    private void Awake()
    {
        _gameManager = DependencyResolver.Container.Resolve<IGameManager>();

    }

    public SymbolData GetSymbolDataFromId(int id)
    {
        return _symbolContainer.SymbolData.ToList().First(d => d.Id == id);
    }

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

    public override void StartGame(GameModeConfig matchConfig)
    {
        _matchingPresenter.SetupBoard((MatchingConfigSO)matchConfig);
    }

    public override void ContinueGame()
    {
        base.ContinueGame();
        Debug.Log("_saveManager :" + _saveManager);
        _saveManager = DependencyResolver.Container.Resolve<ISaveManager>();
        var matchSaveData = _saveManager.LoadMatchingSaveData();
  
        _matchingPresenter.OverrideBoardFromSaveData((MatchingConfigSO)_gameManager.GetCurrentGameMode().GameModeConfig[matchSaveData.GameModeId], matchSaveData.Cards);
    }
}