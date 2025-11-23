using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    protected GameManager GameManager;
    public Action OnStartGame;
    public Action OnCompleteGame;

    public void Initialize(GameManager gameManager)
    {
        GameManager = gameManager;
    }

    public virtual void Setup()
    {

    }

    public virtual void StartGame()
    {

    }
}