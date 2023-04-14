using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int attackPower;
    [SerializeField]
    protected float knockback;
    [SerializeField]
    protected new Collider2D collider;

    public abstract void Attack();
}
