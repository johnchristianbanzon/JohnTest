using UnityEngine;

[CreateAssetMenu(menuName = "GameMode/BaseGame", order = 31)]
public class GameModeSO : ScriptableObject
{
    public string Name;
    public GameController Controller;
}
