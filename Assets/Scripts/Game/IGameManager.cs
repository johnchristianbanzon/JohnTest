public interface IGameManager 
{
    public void ContinueGame();
    public GameModeSO GetCurrentGameMode();
    public void StartGame(GameModeConfig gameModeConfig);
}

