using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    StartMenu,
    Swimming,
    GameOver,
    Upgrading
}

public class GameManager : StaticMonoBehaviour<GameManager>
{
    public LayerMask sharkLayerMask;
    
    private GameState _currentGameState;
    private Camera mainCamera;

    public GameState GameState => _currentGameState;

    void Start()
    {
        mainCamera = Camera.main;
        SetState(GameState.StartMenu);
    }

    void Update()
    {
        if (_currentGameState == GameState.StartMenu || _currentGameState == GameState.GameOver)
        {
            return;
        }
        
    }

    public void SetState(GameState newState)
    {
        switch (newState)
        {
            case GameState.StartMenu:
                break;
            case GameState.Swimming:
                PlayerManager.Instance.StartRun();
                break;
            case GameState.GameOver:
                EndRun();
                break;
            case GameState.Upgrading:
                break;
        }

        _currentGameState = newState;
    }   

    void EndRun()
    {
        UIManager.Instance.OpenUpgradeMenu();
    }
}
