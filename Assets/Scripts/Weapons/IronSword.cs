using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronSword : Weapon
{
    private void Start()
    {
        attackPower = 20;
        knockback = 2;
        EnableTimer = 0.2f;
        DisableTimer = 0.5f;

        InvokeRepeating("EndAttack", 5, 5);
    }
}
