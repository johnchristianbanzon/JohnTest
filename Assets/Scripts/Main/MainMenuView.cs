using System;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuView : BaseView
{
    [SerializeField]
    private GameObject _menuButtonsContainer;
    private GenericButtonBehavior _continueButton;

    public override void Show()
    {
        base.Show();

    }

    public void ShowMenuButtons(GameModeConfig[] matchingConfigs, Action<GameModeConfig> onClickGameButton)
    {
        for (int i = 0; i < matchingConfigs.Length; i++)
        {
            var button = _resourceManager.SpawnPrefab("MediumButton",_menuButtonsContainer.transform).GetComponent<GenericButtonBehavior>();
            var matchConfig = matchingConfigs[i];
            button.SetText(matchingConfigs[i].Name);
            button.SetButtonEvent(delegate
            {
                onClickGameButton?.Invoke(matchConfig);
            });
        }
    }

    public void ShowContinueButton(Action OnClickContinueButton)
    {
        if (_continueButton!=null)
        {
            _continueButton.gameObject.SetActive(true);
            _continueButton.transform.SetAsFirstSibling();
            return;
        }
        _continueButton = _resourceManager.SpawnPrefab("MediumButton", _menuButtonsContainer.transform).GetComponent<GenericButtonBehavior>();
        _continueButton.SetText("Continue");
        _continueButton.SetButtonEvent(delegate
        {
            OnClickContinueButton?.Invoke();
        });
    }

    public void HideContinueButton()
    {
        _continueButton.gameObject.SetActive(false);
    }
}
