using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronDagger : Weapon
{
    private void Start()
    {
        attackPower = 15;
        knockback = 2;
        EnableTimer = 0.05f;
        DisableTimer = 0.3f;
    }
}
