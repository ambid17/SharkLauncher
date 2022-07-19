using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudUI : MonoBehaviour
{
    public Slider staminaSlider;
    
    void Start()
    {
        
    }

    void Update()
    {
        staminaSlider.value = PlayerManager.Instance.playerRunStats.currentStamina /
                              PlayerManager.Instance.GetMaxStamina();
    }
}
