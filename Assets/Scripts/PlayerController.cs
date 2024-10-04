using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _playerSpeed;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private SpriteRenderer _playerSprite;
    [SerializeField] private LayerMask _grassLayer;
    [SerializeField] private int _stepsInGrass;
    
    
    private Rigidbody _playerRigidbody;
    private Vector3 _movement;
    private PlayerControls _playerControls;
    private bool _movingInGrass;
    private float _stepTimer;
    
    
    private const string IS_WALK_PARAM = "IsWalking";
    private const float _timePerStep = 0.5f;

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

        
        // Checks if we are moving and colliding with grass
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1, _grassLayer);
        _movingInGrass = colliders.Length != 0 && _movement != Vector3.zero;

        if (!_movingInGrass) return;
        
        _stepTimer += Time.fixedDeltaTime;
        
        // Increases the steps in grass so we can transition to battle scene once the threshold steps have been hit
        if (_stepTimer > _timePerStep)
        {
            _stepsInGrass++;
            _stepTimer = 0;
        }

    }
}
