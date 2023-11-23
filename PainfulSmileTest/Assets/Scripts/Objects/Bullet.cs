using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IDamageable
{
    [SerializeField] private float _bulletDamage;

    private Rigidbody2D _rigidbody2D;

    private Vector2 _direction;
    private float _currentSpeed;
    private HealthSystem _owner;

    void Start()
    {
        GetBulletComponents();
    }

    void Update()
    {
        BulletAcceleration();
    }

    public void AddBulletForce(Vector2 direction, float force, HealthSystem owner)
    {
        _direction = direction;
        _currentSpeed = force;
        _owner = owner;
       // Destroy(this.gameObject, 1f);
    }

    private void GetBulletComponents()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void BulletAcceleration()
    {
        _rigidbody2D.velocity = _direction * _currentSpeed;
    }

    public float GetDamage()
    {
        return _bulletDamage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<HealthSystem>() && other.gameObject.GetComponent<HealthSystem>() != _owner)
        {
            Destroy(this.gameObject);
        }
    }

    public HealthSystem GetOwner()
    {
        return _owner;
    }
}
