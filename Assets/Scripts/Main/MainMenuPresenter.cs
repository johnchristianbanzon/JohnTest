using static UnityEditor.Profiling.HierarchyFrameDataView;

public class MainMenuPresenter : BasePresenter<MainMenuModel,MainMenuView>
{


    protected override void OnInitialize()
    {
        View.Show();
        //show buttons for main menu available which are game difficulties/stages.
        if (Model.HasContinueButton())
        {
            View.ShowContinueButton(Model.OnContinueGame);
        }
        View.ShowMenuButtons(Model.GetMenuGameConfigs(), OnClickGameButton);

    }
    public void CheckMainMenu()
    {
        if (Model.HasContinueButton())
        {
            View.ShowContinueButton(Model.OnContinueGame);
        }
        else
        {
            View.HideContinueButton();
        }
    }

    private void OnClickGameButton(GameModeConfig matchingConfigSO)
    {
        UnityEngine.Debug.Log("CLICING!! :" + matchingConfigSO.Name);
        Model.OnStartGame(matchingConfigSO);
       
    }
}