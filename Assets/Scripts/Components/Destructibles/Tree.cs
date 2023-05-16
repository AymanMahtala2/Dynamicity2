using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : DestructibleObject
{
    void Start()
    {
        speed = 23f; //how fast it shakes
        amount = 0.08f; //how much it shakes
    }

    public override void GetHit()
    {
        Debug.Log("kankerzooi");
    }
}   
