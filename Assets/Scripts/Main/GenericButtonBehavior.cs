using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GenericButtonBehavior : MonoBehaviour
{
    private Button _button;

    // Start is called before the first frame update
    public void Start()
    {
        _button = GetComponent<Button>();
    
    }

    public void SetButtonEvent(Action onClickButton)
    {
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(delegate
        {
            onClickButton?.Invoke();
        });
    }


}
