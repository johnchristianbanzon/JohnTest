using UnityEngine;

public class UIManager : MonoBehaviour, IUIManager
{
    [SerializeField]
    private Canvas MainCanvas;

    public Canvas GetMainCanvas()
    {
        return MainCanvas;
    }
}
