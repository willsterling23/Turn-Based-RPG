using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _playerSpeed;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private SpriteRenderer _playerSprite;
    [SerializeField] private LayerMask _grassLayer;
    [SerializeField] private int _stepsInGrass;
    [SerializeField] private int _minStepsToEncounter;
    [SerializeField] private int _maxStepsToEncounter;
    
    
    private Rigidbody _playerRigidbody;
    private Vector3 _movement;
    private PlayerControls _playerControls;
    private bool _movingInGrass;
    private float _stepTimer;
    private int _stepsToEncounter;
    
    
    private const string IS_WALK_PARAM = "IsWalking";
    private const float TIME_PER_STEP = 0.5f;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _stepsToEncounter = Random.Range(_minStepsToEncounter, _maxStepsToEncounter);
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
        
        GetPlayerGrassPosition();
        if (!_movingInGrass) return;
        
        CalculateStepsToBattleScene();
    }

    private void CalculateStepsToBattleScene()
    {
        _stepTimer += Time.fixedDeltaTime;
        if (_stepTimer > TIME_PER_STEP)
        {
            _stepsInGrass++;
            _stepTimer = 0;

            if (_stepsInGrass >= _stepsToEncounter)
            {
                SceneManager.LoadScene("BattleScene");
            }
        }
    }

    private void GetPlayerGrassPosition()
    {
        var colliders = Physics.OverlapSphere(transform.position, 1, _grassLayer);
        _movingInGrass = colliders.Length != 0 && _movement != Vector3.zero;
    }

    
}
