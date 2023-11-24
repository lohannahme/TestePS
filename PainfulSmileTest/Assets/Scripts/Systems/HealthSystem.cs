using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float _maxLife = 10;

    private float _currentLife;

    public static Action<HealthSystem, float, float> OnTakeDamage;

    private void Start()
    {
        _currentLife = _maxLife;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            if(damageable.GetOwner() != this)
            {
                TakeDamage(damageable.GetDamage());
            }
        }
    }

    private void TakeDamage(float damage)
    {
        _currentLife -= damage;
        OnTakeDamage?.Invoke(this, _maxLife, _currentLife);
        if(_currentLife <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
