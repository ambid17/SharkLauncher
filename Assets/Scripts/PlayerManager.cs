using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : StaticMonoBehaviour<PlayerManager>
{
    public PlayerController playerController;
    public FollowCamera followCamera;
    public PlayerUpgradeModel playerUpgrades;
    public PlayerRunStats playerRunStats;
    
    void Start()
    {
        playerRunStats = new PlayerRunStats();
    }

    private void Update()
    {
        if (GameManager.Instance.GameState != GameState.Swimming)
        {
            return;
        }
        CheckGameOver();
    }

    public void StartRun()
    {
        playerRunStats.currentStamina = GetMaxStamina();
    }

    public float GetMaxStamina()
    {
        return playerUpgrades.maxBaseStamina + (playerUpgrades.staminaPerUpgrade * playerUpgrades.staminaUpgrades);
    }
    
    private void CheckGameOver()
    {
        if (playerRunStats.currentStamina <= 0)
        {
            GameManager.Instance.SetState(GameState.GameOver);
        }
    }

    public float GetSpeed()
    {
        return 5 + (2 * playerUpgrades.speedUpgrades);
    }
}
