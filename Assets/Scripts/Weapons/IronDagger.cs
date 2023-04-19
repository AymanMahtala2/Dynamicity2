using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronDagger : Weapon
{
    private void Start()
    {
        attackPower = 20;
        knockback = 2;
    }
    public override void Attack()
    {
        Invoke("EnableColliding", 0.05f);
        Invoke("StopColliding", 0.3f);
    }

    private void EnableColliding()
    {
        collider.enabled = true;
    }

    private void StopColliding()
    {
        collider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Body" || collision.tag == "PlayerBody")
        {
            collision.transform.parent.GetComponent<MovingCharacter>().TakeDamage(attackPower, transform.up * knockback);
            Debug.Log(transform.up * knockback);
        }
    }
}
