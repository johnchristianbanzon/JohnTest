using UnityEngine;

public class ResourceManager : IResourceManager
{
    public GameObject SpawnGenericPrefab(EnumGenericResourceKey prefabKey, Transform parent)
    {
        return GameObject.Instantiate(Resources.Load("Prefabs/"+ prefabKey), parent) as GameObject;
    }

    public GameObject SpawnPrefab(string customkey, Transform parent= null)
    {
        return GameObject.Instantiate(Resources.Load("Prefabs/" + customkey), parent==null ? DependencyResolver.Container.Resolve<IUIManager>().GetMainCanvas().transform : parent) as GameObject;
    }
}