using UnityEngine;

public class GameController : MonoBehaviour
{
    protected GameManager GameManager;

    public void Initialize(GameManager gameManager)
    {
        GameManager = gameManager;
    }

    public virtual void StartGame()
    {

    }
}