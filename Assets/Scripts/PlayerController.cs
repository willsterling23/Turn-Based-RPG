using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _playerSpeed;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private SpriteRenderer _playerSprite;
    
    
    private Rigidbody _playerRigidbody;
    private Vector3 _movement;
    private PlayerControls _playerControls;
    
    private const string IS_WALK_PARAM = "IsWalking";

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
        
        _playerAnimator.SetBool(IS_WALK_PARAM, _movement != Vector3.zero);
        _playerSprite.flipX = _movement.x < 0;

    }

    private void FixedUpdate()
    {
        _playerRigidbody.MovePosition(transform.position + _movement * (_playerSpeed * Time.fixedDeltaTime));
    }
}
