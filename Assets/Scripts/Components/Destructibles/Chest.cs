using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : DestructibleObject
{
    public Animator animator;

    void Start()
    {
        speed = 23f; //how fast it shakes
        amount = 0.08f; //how much it shakes
    }

    public override void GetHit(int attackPower)
    {
        Debug.Log("open itt");
        
        animator.SetBool("OpenIt", true);
        //animator.ResetTrigger("OpenIt");

        //base.GetHit(attackPower);
    }

    //public override void Die()
    //{
    //    Debug.Log("im dead");
    //    animator.SetTrigger("OpenIt");
    //    //animator.ResetTrigger("OpenIt");
    //}
}
