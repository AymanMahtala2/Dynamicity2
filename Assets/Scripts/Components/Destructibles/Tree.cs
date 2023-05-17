using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : DestructibleObject
{
    [SerializeField]
    private new int health;

    void Start()
    {
        speed = 23f; //how fast it shakes
        amount = 0.08f; //how much it shakes
        base.health = health;
    }

    //public override void GetHit(int attackPower)
    //{
    //    base.GetHit(attackPower);
    //}
}   
