using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _accelerationSpeed = 5;
    [SerializeField] private float _damping = 5;

    [SerializeField] private GameObject _playerSprite;
    private PlayerControls _playerControls;
    private Rigidbody2D _rigidbody2D; 

    private float _maxShipSpeed = 5;
    private float _currentSpeed;
    private float _mover;
    private float _direction;

    private void Awake()
    {
        CreatePlayerInputs();
    }

    private void OnEnable()
    {
        EnableInputs();
    }

    private void OnDisable()
    {
        DisableInputs();
    }

    void Start()
    {
        GetComponents();
    }

    private void Update()
    {
        ShipAcceleration();
    }

    void FixedUpdate()
    {
        RotateShip();
        MoveShip();
    }

    private void OnRotatePerformed(InputAction.CallbackContext ctx)
    {
        _direction = ctx.ReadValue<float>();
    }

    private void OnRotateCanceled(InputAction.CallbackContext ctx)
    {
        _direction = 0;
    }

    private void OnAcceleratePerformed(InputAction.CallbackContext ctx)
    {
        _mover = ctx.ReadValue<float>();
    }

    private void OnAccelerateCanceled(InputAction.CallbackContext ctx)
    {
        _mover = 0;
    }

    private void RotateShip()
    {
        _playerSprite.transform.Rotate(Vector3.forward * (_direction * _rotateSpeed));
    }

    private void MoveShip()
    {
        Vector2 direction = new Vector2(-_playerSprite.transform.up.x, -_playerSprite.transform.up.y);
        _rigidbody2D.velocity = direction * _currentSpeed;
    }

    private void ShipAcceleration()
    {
        if (_mover != 0 && _currentSpeed < _maxShipSpeed)
        {
            _currentSpeed += _accelerationSpeed * Time.deltaTime;
        }

        if (_mover == 0 && _currentSpeed > 0)
        {
            _currentSpeed -= _damping * Time.deltaTime;
            if (_currentSpeed < 0)
            {
                _currentSpeed = 0;
            }
        }
    }

    private void CreatePlayerInputs()
    {
        _playerControls = new PlayerControls();
    }

    private void GetComponents()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void EnableInputs()
    {
        _playerControls.Enable();
        _playerControls.Player.Rotate.performed += OnRotatePerformed;
        _playerControls.Player.Rotate.canceled += OnRotateCanceled;

        _playerControls.Player.Accelerate.performed += OnAcceleratePerformed;
        _playerControls.Player.Accelerate.canceled += OnAccelerateCanceled;
    }

    private void DisableInputs()
    {
        _playerControls.Disable();
        _playerControls.Player.Rotate.performed -= OnRotatePerformed;
        _playerControls.Player.Rotate.canceled -= OnRotateCanceled;

        _playerControls.Player.Accelerate.performed -= OnAcceleratePerformed;
        _playerControls.Player.Accelerate.canceled -= OnAccelerateCanceled;
    }
}
