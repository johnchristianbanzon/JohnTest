using UnityEngine;

public abstract class BaseView : MonoBehaviour
{
    protected IResourceManager _resourceManager;

    private void Awake()
    {
        _resourceManager = DependencyResolver.Container.Resolve<IResourceManager>();
    }

    public virtual void Initialize() { }
    public virtual void Show() => gameObject.SetActive(true);
    public virtual void Hide() => gameObject.SetActive(false);
}
