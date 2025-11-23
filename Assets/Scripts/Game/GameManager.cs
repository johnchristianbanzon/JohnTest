using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameModeSO CurrentGameMode;

    private void Start()
    {
        InitializeGame();
    }

    public void InitializeGame()
    {
        var controllerInstance = Instantiate(CurrentGameMode.Controller);
        controllerInstance.Initialize(this);
        controllerInstance.StartGame();
    }

}