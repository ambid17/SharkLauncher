using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float followSpeed = 10;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.GameState == GameState.Launch || GameManager.Instance.GameState == GameState.Launching)
        {
            transform.position = new Vector3(0, 0, -15);
        }
        else
        {
            Vector3 targetPos = PlayerManager.Instance.playerController.transform.position;
            targetPos.z = -15;
            transform.position = Vector3.Lerp(transform.position,targetPos, Time.fixedDeltaTime * followSpeed);
        }
    }
}
