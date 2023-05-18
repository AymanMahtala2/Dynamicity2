using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : DestructibleObject
{
    public Animator animator;


    public override void Die()
    {
        Debug.Log("open itt");
        animator.SetBool("PlayOpen", true);
        isHit = true;
    }

    //public override void Die()
    //{
    //    Debug.Log("im dead");
    //    animator.SetTrigger("OpenIt");
    //    //animator.ResetTrigger("OpenIt");
    //}
}
