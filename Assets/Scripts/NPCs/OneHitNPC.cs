using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHitNPC : Character
{
    private void Start()
    {
        base.Start();
        health = 10;
        speed = 2;
        if (GameManager.instance.NPCGuide[NPCNumber] == GameManager.State.Dead)
        {
            Destroy(gameObject);
        }
    }
}
