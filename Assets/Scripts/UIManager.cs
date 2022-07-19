using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIState
{
    Start,
    InGame,
    Upgrading
}
public class UIManager : StaticMonoBehaviour<UIManager>
{
    public Transform startMenu;
    public Transform upgradeMenu;

    public Button startButton;
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        startMenu.gameObject.SetActive(true);
        upgradeMenu.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    private void StartGame()
    {
        GameManager.Instance.SetState(GameState.Swimming);
        startMenu.gameObject.SetActive(false);
        upgradeMenu.gameObject.SetActive(false);
    }

    public void OpenUpgradeMenu()
    {
        upgradeMenu.gameObject.SetActive(true);
    }

    public void FinishUpgrading()
    {
        upgradeMenu.gameObject.SetActive(false);
        GameManager.Instance.SetState(GameState.Swimming);
    }
    
}
