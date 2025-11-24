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

    private void OnClickGameButton(GameModeConfig matchingConfigSO)
    {
        UnityEngine.Debug.Log("CLICING!! :" + matchingConfigSO.Name);
        Model.OnStartGame(matchingConfigSO);
       
    }
}