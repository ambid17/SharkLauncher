using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float followSpeed = 10;
    void Start()
    {
        
    }

    void LateUpdate()
    {
        Vector3 targetPos = PlayerManager.Instance.playerController.transform.position;
        targetPos.z = -15;
        transform.position = targetPos;
    }
}
