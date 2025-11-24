using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    private IUIManager _uiManager;

    private void Start()
    {
        _uiManager = DependencyResolver.Container.Resolve<IUIManager>();
        InitializeGame();
    }

    private void InitializeGame()
    {
        _uiManager.ShowMainMenu();

    }
}