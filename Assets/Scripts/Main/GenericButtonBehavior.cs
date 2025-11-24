using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GenericButtonBehavior : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    [SerializeField]
    private Text _text;

    public void SetButtonEvent(Action onClickButton)
    {
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(delegate
        {
            onClickButton?.Invoke();
        });
    }

    public void SetText(string text)
    {
        _text.text = text;
    }

}
