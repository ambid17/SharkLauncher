using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private Vector3 startPosition;

    private int platformLayer = 7;
    private int groundLayer = 7;

    private int lowPlatformForce = 1;
    private int mediumPlatformForce = 5;
    private int highPlatformForce = 15;
    [SerializeField] private float killFloorY = -15;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
        _rigidbody.MovePosition(Vector3.zero);
        startPosition = Vector3.zero;
    }

    void Update()
    {
        if (GameManager.Instance.GameState == GameState.GameOver)
        {
            return;
        }

        if (GameManager.Instance.GameState == GameState.Swimming)
        {
            MovePlayer();
            CheckGameOver();
        }
        
    }

    void MovePlayer()
    {
        if (!PlayerManager.Instance.playerRunStats.HasStamina())
        {
            return;
        }
        
        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -PlayerManager.Instance.GetHorizontalSpeed();
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement.x = PlayerManager.Instance.GetHorizontalSpeed();
        }

        if (movement.magnitude > 0)
        {
            _rigidbody.AddForce(movement, ForceMode.Force);
            PlayerManager.Instance.playerRunStats.UseStamina(Time.deltaTime);
            
            Debug.Log("used stamina: " + Time.deltaTime);
        }
    }

    public void StartLaunch()
    {
        _rigidbody.isKinematic = true;
        _rigidbody.MovePosition(Vector3.zero);
        startPosition = Vector3.zero;
    }

    public void Launch()
    {
        Vector3 offsetForce = -transform.position * PlayerManager.Instance.GetLaunchPower();
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(offsetForce, ForceMode.VelocityChange);
    }

    public void UpdateLaunchPosition(Vector3 newPos)
    {
        _rigidbody.MovePosition(newPos);
    }
    
    
    private void CheckGameOver()
    {
        if (transform.position.y <= killFloorY)
        {
            GameManager.Instance.SetState(GameState.GameOver);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == platformLayer)
        {
            Platform platform = other.gameObject.GetComponent<Platform>();
            AddPlatformForce(platform.platformType);
            Destroy(other.gameObject);
        }
    }

    private void AddPlatformForce(PlatformType platformType)
    {
        Vector3 forceToAdd = Vector3.zero;

        if (platformType == PlatformType.Low)
        {
            forceToAdd = new Vector3(0, lowPlatformForce, 0);
        }
        else if (platformType == PlatformType.Medium)
        {
            forceToAdd = new Vector3(0, mediumPlatformForce, 0);
        }
        else if (platformType == PlatformType.High)
        {
            forceToAdd = new Vector3(0, highPlatformForce, 0);
        }
        
        _rigidbody.AddForce(forceToAdd);
    }
}
