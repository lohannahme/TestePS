using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private GameObject _shipSprite;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _frontBulletSpawn;
    [SerializeField] private Transform[] _rightSideBulletSpawn;
    [SerializeField] private Transform[] _leftSideBulletSpawn;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Bullet b = Instantiate(_bulletPrefab, _frontBulletSpawn.transform.position, Quaternion.identity).GetComponent<Bullet>();

            b.AddBulletForce(new Vector2(-_shipSprite.transform.up.x, -_shipSprite.transform.up.y), 10, GetComponent<HealthSystem>());

        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            for (int i = 0; i < _rightSideBulletSpawn.Length; i++)
            {
                Bullet b = Instantiate(_bulletPrefab, _rightSideBulletSpawn[i].transform.position, Quaternion.identity).GetComponent<Bullet>();

                b.AddBulletForce(new Vector2(_shipSprite.transform.right.x, _shipSprite.transform.right.y), 6, GetComponent<HealthSystem>());
            }
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            for (int i = 0; i < _leftSideBulletSpawn.Length; i++)
            {
                Bullet b = Instantiate(_bulletPrefab, _leftSideBulletSpawn[i].transform.position, Quaternion.identity).GetComponent<Bullet>();

                b.AddBulletForce(new Vector2(-_shipSprite.transform.right.x, -_shipSprite.transform.right.y), 6, GetComponent<HealthSystem>());
            }
        }
    }
}
