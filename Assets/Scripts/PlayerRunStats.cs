using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerRunStats
{
    public float currentStamina;

    public PlayerRunStats()
    {
        currentStamina = 100;
    }
    
    public PlayerRunStats(float maxStamina)
    {
        currentStamina = maxStamina;
    }

    public bool HasStamina()
    {
        return currentStamina > 0;
    }

    public void UseStamina(float staminaUsed)
    {
        currentStamina -= staminaUsed;
    }
}
