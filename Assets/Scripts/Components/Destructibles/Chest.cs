using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : DestructibleObject
{
    public Animator animator;

    void Start()
    {
        spawnHeight = 0.5f;
    }

    public override void Die()
    {
        animator.SetBool("PlayOpen", true);
        isHit = true;
    }
}
