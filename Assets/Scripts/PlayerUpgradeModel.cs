using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "PlayerUpgradeModel", menuName = "ScriptableObjects/PlayerUpgradeModel", order = 1)]
public class PlayerUpgradeModel : ScriptableObject
{
    [SerializeField]
    public int speedUpgrades;
    [SerializeField]
    public int maxBaseStamina;
    [SerializeField]
    public int staminaUpgrades;
    [SerializeField]
    public int staminaPerUpgrade;
}
