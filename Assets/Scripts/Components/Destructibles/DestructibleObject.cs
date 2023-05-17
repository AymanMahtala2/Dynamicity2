using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DestructibleObject : MonoBehaviour
{
    public int health;

    protected float speed;
    protected float amount;

    private bool isHit = false;
    private bool isAnimating = false;
    protected float xPos;


    public void Collide(int attackPower)
    {
        GetHit(attackPower);
        //if (!isHit)
        //{
        //    GetHit(attackPower);
        //}
        //isHit = true;     
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
        Destroy(this);
    }

    public virtual void Animate()
    {
        xPos = transform.position.x;
        amount = 0.08f;
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

    public void Update()
    {
        //if (isAnimating)
        //{
        //    float xVal = xPos + Mathf.Sin(Time.time * speed) * amount;
        //    amount = amount / 1.001f;

        //    if (amount < 0.05)
        //    {
        //        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        //        isHit = false;
        //        isAnimating = false;
        //    }
        //    transform.position = new Vector3(xVal, transform.position.y, transform.position.z); 
        //}
    }
}
