using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls _playerControls;
    private Rigidbody2D _rigidbody2D;
    


    [SerializeField]private float _rotateSpeed;
    [SerializeField]private float _accelerationSpeed = 5;

    private float _maxShipSpeed = 5;
    private float _currentSpeed;
    private float _mover;
    private float _direction;

    private void Awake()
    {
        _playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
        _playerControls.Player.Rotate.performed += OnRotatePerformed;
        _playerControls.Player.Rotate.canceled += OnRotateCanceled;

        _playerControls.Player.Accelerate.performed += OnAcceleratePerformed;
        _playerControls.Player.Accelerate.canceled += OnAccelerateCanceled;
    }

    private void OnDisable()
    {
        _playerControls.Disable();
        _playerControls.Player.Rotate.performed -= OnRotatePerformed;
        _playerControls.Player.Rotate.canceled -= OnRotateCanceled;

        _playerControls.Player.Accelerate.performed -= OnAcceleratePerformed;
        _playerControls.Player.Accelerate.canceled -= OnAccelerateCanceled;
    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(_mover != 0 && _currentSpeed < _maxShipSpeed)
        {
            _currentSpeed += _accelerationSpeed * Time.deltaTime;
        }

        if(_mover == 0 && _currentSpeed > 0)
        {
            _currentSpeed -= (_accelerationSpeed* 5) * Time.deltaTime;
            if(_currentSpeed< 0)
            {
                _currentSpeed = 0;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RotateShip();
        Vector2 direction = new Vector2(transform.up.x, transform.up.y);
        // _rigidbody2D.velocity = direction * Time.fixedDeltaTime * _currentSpeed *_shipSpeed;
        _rigidbody2D.velocity = direction * _currentSpeed;

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
        transform.Rotate(Vector3.forward * (_direction * _rotateSpeed));
    }
}
