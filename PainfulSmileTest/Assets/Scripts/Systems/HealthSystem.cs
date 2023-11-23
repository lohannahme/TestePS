using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float _currentLife = 10;

    private void Start()
    {

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
    }
}
