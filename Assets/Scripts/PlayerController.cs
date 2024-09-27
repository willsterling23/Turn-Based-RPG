using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _playerSpeed;
    
    private Rigidbody _playerRigidbody;
    private Vector3 _movement;
    private PlayerControls _playerControls;

    private void Awake()
    {
        _playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var x = _playerControls.Player.Move.ReadValue<Vector2>().x;
        var z = _playerControls.Player.Move.ReadValue<Vector2>().y;
        
        _movement = new Vector3(x, 0, z).normalized;
        
    }

    private void FixedUpdate()
    {
        _playerRigidbody.MovePosition(transform.position + _movement * (_playerSpeed * Time.fixedDeltaTime));
    }
}
