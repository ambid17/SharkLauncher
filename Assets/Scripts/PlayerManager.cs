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

    public void StartRun()
    {
        playerRunStats.currentStamina = playerUpgrades.maxBaseStamina + (playerUpgrades.staminaPerUpgrade * playerUpgrades.staminaUpgrades);
        playerController.StartLaunch();
    }


    public float GetLaunchPower()
    {
        return (1 + playerUpgrades.launchPowerUpgrades) * 10;
    }

    public float GetHorizontalSpeed()
    {
        return 5 + (2 * playerUpgrades.horizontalSpeedUpgrades);
    }
}
