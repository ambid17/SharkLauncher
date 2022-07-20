using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenuUI : MonoBehaviour
{
    [SerializeField] private Button playAgainButton;
    
    void Start()
    {
        playAgainButton.onClick.AddListener(UIManager.Instance.FinishUpgrading);
    }

    void Update()
    {
        
    }
}
