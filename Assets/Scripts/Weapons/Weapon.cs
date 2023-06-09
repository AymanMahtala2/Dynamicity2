using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int attackPower;
    [SerializeField]
    protected float knockback;
    [SerializeField]
    public new Collider2D collider;

    [SerializeField]
    protected float EnableTimer;
    [SerializeField]
    protected float DisableTimer;
    public virtual void Attack()
    {
        collider.enabled = true;
    }

    public void EndAttack()
    {
        collider.enabled = false;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Character>() != null)
        {
            collision.GetComponent<Character>().TakeDamage(attackPower, knockback);
        }
        else if (collision.GetComponent<DestructibleObject>() != null)
        {
            collision.GetComponent<DestructibleObject>().Collide(attackPower);
        }
    }
}
