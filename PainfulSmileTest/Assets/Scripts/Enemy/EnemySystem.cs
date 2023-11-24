using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyType _enemyType;
    [SerializeField] private float _enemyDamage;

    public float GetDamage()
    {
        return _enemyDamage;
    }

    public HealthSystem GetOwner()
    {
        return null;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_enemyType == EnemyType.Chaser && collision.GetComponent<PlayerMovement>())
        {
            Destroy(this.gameObject);
        }
    }
}
