using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DestructibleObject : MonoBehaviour
{
    protected float speed;
    protected float amount;
    protected int health;

    private bool isHit = false;
    private float xPos;


    //public abstract void GetHit();
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
        Debug.Log("attackPower: " + attackPower);
        this.Animate();
    }

    public virtual void Animate()
    {
        xPos = transform.position.x;
        amount = 0.08f;
    }

    public void Update()
    {
        if (isHit)
        {
            float xVal = xPos + Mathf.Sin(Time.time * speed) * amount;
            amount = amount / 1.001f;

            if (amount < 0.05)
            {
                transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
                isHit = false;
            }
            transform.position = new Vector3(xVal, transform.position.y, transform.position.z); 
        }
    }
}
