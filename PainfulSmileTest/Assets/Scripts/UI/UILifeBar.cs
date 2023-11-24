using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILifeBar : MonoBehaviour
{
    [SerializeField] private Image _lifeBar;

    private HealthSystem _thisHealth;

    private void Start()
    {
        _thisHealth = GetComponentInParent<HealthSystem>();
    }

    private void OnEnable()
    {
        HealthSystem.OnTakeDamage += UpdateLifeBar;
    }

    private void OnDisable()
    {
        HealthSystem.OnTakeDamage -= UpdateLifeBar;
    }

    private void UpdateLifeBar(HealthSystem health, float maxLife, float currentLife)
    {
        if(health == _thisHealth)
        {
            _lifeBar.fillAmount = (currentLife/maxLife);
        }
    }

}
