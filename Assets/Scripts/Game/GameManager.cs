using UnityEngine;

public class GameManager : MonoBehaviour, IGameManager
{
    /// <summary>
    /// Current game mode, to change the game 
    /// </summary>
    public GameModeSO CurrentGameMode;
    private IUIManager _uiManager;

    private void Start()
    {
        _uiManager = DependencyResolver.Container.Resolve<IUIManager>();
    }

    public void StartGame(GameModeConfig gameModeConfig)
    {
        var controllerInstance = Instantiate(CurrentGameMode.Controller, _uiManager.GetMainCanvas().transform);
        controllerInstance.Initialize(this);
        controllerInstance.Setup();
        controllerInstance.StartGame(gameModeConfig);
    }

    public GameModeSO GetCurrentGameMode()
    {
        return CurrentGameMode;
    }

    public void ContinueGame()
    {
        var controllerInstance = Instantiate(CurrentGameMode.Controller, _uiManager.GetMainCanvas().transform);
        controllerInstance.Initialize(this);
        controllerInstance.Setup();
        controllerInstance.ContinueGame();
    }
}