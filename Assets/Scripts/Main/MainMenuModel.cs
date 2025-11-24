public class MainMenuModel : BaseModel
{

    private IGameManager _gameManger;
    private ISaveManager _saveManager;
    private IUIManager _uiManager;

    public override void Initialize()
    {
        base.Initialize();
        _gameManger = DependencyResolver.Container.Resolve<IGameManager>();
        _uiManager = DependencyResolver.Container.Resolve<IUIManager>();
        _saveManager = DependencyResolver.Container.Resolve<ISaveManager>();

    }

    public bool HasContinueButton()
    {
        return _saveManager.LoadMatchingSaveData()!=null;
    }

    public void OnContinueGame()
    {
        _gameManger.ContinueGame();
        _uiManager.HideMainMenu();
    }

    public void OnStartGame(GameModeConfig matchingConfigSO)
    {
        _gameManger.StartGame(matchingConfigSO);
        _uiManager.HideMainMenu();
    }

    public GameModeConfig[] GetMenuGameConfigs()
    {
        return _gameManger.GetCurrentGameMode().GameModeConfig;
    }
}