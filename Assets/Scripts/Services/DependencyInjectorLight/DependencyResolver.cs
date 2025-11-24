using UnityEngine;


/// <summary>
/// Zenject alternative, used as a DIContainer
/// </summary>
public class DependencyResolver : MonoBehaviour
{
    public static DIContainer Container { get; private set; }
    [SerializeField]
    private GameManager _gameManager;
    [SerializeField]
    private UIManager _uiManager;

    private void Awake()
    {
        Container = new DIContainer();

        Container.Register<IGameManager>(_gameManager);
        Container.Register<IUIManager>(_uiManager);
        Container.Register<IResourceManager>(new ResourceManager());
    }
}