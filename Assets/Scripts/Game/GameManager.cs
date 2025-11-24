using UnityEngine;

public class GameManager : MonoBehaviour, IGameManager
{
    public GameModeSO CurrentGameMode;
    private IUIManager _uiManager;

    private void Start()
    {
        _uiManager = DependencyResolver.Container.Resolve<IUIManager>();
        Debug.Log("_uiManager 3:" + _uiManager);
        InitializeGame();
    }

    public void InitializeGame()
    {
        var controllerInstance = Instantiate(CurrentGameMode.Controller, _uiManager.GetMainCanvas().transform);
        controllerInstance.Initialize(this);
        controllerInstance.Setup();
        controllerInstance.StartGame();
    }

}