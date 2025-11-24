using UnityEngine;

public interface IResourceManager
{
    public GameObject SpawnPrefab(string customkey, Transform parent = null);
}