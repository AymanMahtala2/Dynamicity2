using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DestructibleObject : MonoBehaviour
{
    public ItemObject droppable;
    public int health;

    protected float speed = 23f;
    protected float amount = 0.07f;
    protected bool isHit = false;

    private bool isAnimating = false;
    protected float xPos;


    public void Collide(int attackPower)
    {
        if (!isHit)
        {
            GetHit(attackPower);
        }
        isHit = true;
    }

    public virtual void GetHit(int attackPower)
    {
        health = health - attackPower;
        Debug.Log("health: " + health);
        if (health <= 0)
        {
            Die();
        } else
        {
            this.Animate();
        }
    }

    public virtual void Die()
    {
        Debug.Log("dead");
        GetComponent<SpriteRenderer>().enabled = false;
        DropItem();
        Destroy(this);
    }

    public void DropItem()
    {
        if (droppable != null)
        {
            Debug.Log("dropping item");
            ItemObject item = Instantiate(droppable);
            item.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            item.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 3, 0), ForceMode2D.Impulse);

        } else
        {
            Debug.Log("no droppable assigned");
        }
    }

    public virtual void Animate()
    {
        xPos = transform.position.x;
        amount = 0.07f;
        isAnimating = true;
    }

    public void FixedUpdate()
    {
        if (isAnimating)
        {
            float xVal = xPos + Mathf.Sin(Time.time * speed) * amount;
            amount = amount / 1.01f;

            if (amount < 0.05)
            {
                transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
                isHit = false;
                isAnimating = false;
            }
            transform.position = new Vector3(xVal, transform.position.y, transform.position.z);
        }
    }

}
