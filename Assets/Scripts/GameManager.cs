using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    StartMenu,
    Launch,
    Launching,
    Swimming,
    GameOver,
    Upgrading
}

public class GameManager : StaticMonoBehaviour<GameManager>
{
    public LayerMask sharkLayerMask;
    
    private GameState _currentGameState;
    private Camera mainCamera;

    private Vector3 startLaunchPosition;

    public GameState GameState => _currentGameState;

    void Start()
    {
        mainCamera = Camera.main;
        startLaunchPosition = Vector3.zero;;
        SetState(GameState.StartMenu);
    }

    void Update()
    {
        if (_currentGameState == GameState.StartMenu || _currentGameState == GameState.GameOver)
        {
            return;
        }
        
        if (_currentGameState == GameState.Launch)
        {
            TryStartLaunch();
        }

        if (_currentGameState == GameState.Launching)
        {
            TrackMouse();
            TryLaunch();
        }

        if (_currentGameState == GameState.Swimming)
        {
            EndRun();
        }
    }

    public void SetState(GameState newState)
    {
        switch (newState)
        {
            case GameState.Launch:
                PlayerManager.Instance.StartRun();
                break;
            case GameState.Swimming:
                PlayerManager.Instance.playerController.Launch();
                break;
            case GameState.GameOver:
                EndRun();
                break;
        }

        _currentGameState = newState;
    }

    void TryStartLaunch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            Ray ray = mainCamera.ScreenPointToRay(mousePos);
            if (Physics.Raycast(ray, out RaycastHit hit, sharkLayerMask))
            {
                startLaunchPosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, PlayerManager.Instance.playerController.transform.position.z));
                SetState(GameState.Launching);
            }
        }
    }

    void TrackMouse()
    {
        if (Input.GetMouseButton(0))
        {
            float zOffset = Mathf.Abs(mainCamera.transform.position.z -
                                      PlayerManager.Instance.playerController.transform.position.z);
            Vector2 mousePos = Input.mousePosition;
            Vector3 currentLaunchPosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, zOffset));
            PlayerManager.Instance.playerController.UpdateLaunchPosition(currentLaunchPosition);
        }
    }
    
    void TryLaunch()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SetState(GameState.Swimming);
        }
    }

    void EndRun()
    {
        UIManager.Instance.OpenUpgradeMenu();
    }
}
