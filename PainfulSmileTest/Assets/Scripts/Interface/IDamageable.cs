using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
    float GetDamage();
    HealthSystem GetOwner();
}
