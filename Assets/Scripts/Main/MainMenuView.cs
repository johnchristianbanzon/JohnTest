using System;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuView : BaseView
{
    [SerializeField]
    private GameObject _menuButtonsContainer;


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
        var button = _resourceManager.SpawnPrefab("MediumButton", _menuButtonsContainer.transform).GetComponent<GenericButtonBehavior>();
        button.SetText("Continue");
        button.SetButtonEvent(delegate
        {
            OnClickContinueButton?.Invoke();
        });
    }
}
