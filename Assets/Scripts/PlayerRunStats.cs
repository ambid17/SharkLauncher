using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
[CreateAssetMenu(fileName = "PlayerRunStats", menuName = "ScriptableObjects/PlayerRunStats", order = 1)]
public class PlayerRunStats : ScriptableObject
{
    public float currentStamina;
    public float staminaDrainMultiplier;

    public PlayerRunStats()
    {
        currentStamina = 5;
        staminaDrainMultiplier = 1;
    }
    
    public PlayerRunStats(float maxStamina)
    {
        currentStamina = maxStamina;
    }

    public bool HasStamina()
    {
        return currentStamina > 0;
    }

    public void UseStamina()
    {
        currentStamina -= Time.deltaTime * staminaDrainMultiplier;
    }
}
