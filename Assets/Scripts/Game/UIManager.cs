using System.Resources;
using UnityEngine;

public class UIManager : MonoBehaviour, IUIManager
{
    [SerializeField]
    private Canvas MainCanvas;
    private MainMenuPresenter _mainMenu;


    public Canvas GetMainCanvas()
    {
        return MainCanvas;
    }

    public void ShowMainMenu()
    {
        if (_mainMenu != null)
        {
            _mainMenu.Show();
            return;
        }
        var resourceManager = DependencyResolver.Container.Resolve<IResourceManager>();
        var mainMenu = resourceManager.SpawnPrefab("MainMenu").GetComponent<MainMenuView>();
        _mainMenu = new MainMenuPresenter();
        _mainMenu.Initialize(new MainMenuModel(), mainMenu);
    }

    public void HideMainMenu()
    {
        _mainMenu?.Hide();
    }
}
