using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject sharkModel;
    [SerializeField] private float rotationSpeed;
    private Rigidbody _rigidbody;

    private int fishLayer = 7;
    private int groundLayer = 7;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (GameManager.Instance.GameState != GameState.Swimming)
        {
            return;
        }
        
        MovePlayer();
        PlayerManager.Instance.playerRunStats.UseStamina();
    }

    public void StartRun()
    {
        _rigidbody.isKinematic = true;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        _rigidbody.isKinematic = false;
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical, 0);
        movement.Normalize();
        movement *= PlayerManager.Instance.GetSpeed();

        _rigidbody.AddForce(movement);

        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            _rigidbody.MoveRotation(targetRotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == fishLayer)
        {
            Destroy(other.gameObject);
        }
    }
}
