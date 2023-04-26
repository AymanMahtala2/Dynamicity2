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
        StartCoroutine(Colliding());
    }
    protected IEnumerator Colliding()
    {
        yield return new WaitForSeconds(EnableTimer);
        collider.enabled = true;
        yield return new WaitForSeconds(DisableTimer);
        collider.enabled = false;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Character>() != null)
        {
            collision.GetComponent<Character>().TakeDamage(attackPower, knockback);
        }
    }
}
