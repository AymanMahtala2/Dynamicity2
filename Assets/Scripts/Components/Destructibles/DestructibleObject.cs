using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DestructibleObject : MonoBehaviour
{
    protected float speed;
    protected float amount;
    private bool isShaking = false;
    private float xPos;
    protected string kanker;


    //public abstract void GetHit();
    public virtual void GetHit()
    {
        this.Animate();        
    }

    public virtual void Animate()
    {
        if (!isShaking)
        {
            Debug.Log("object is hit");
            xPos = transform.position.x;
            amount = 0.08f;
        }
        isShaking = true;
    }

    public void Update()
    {
        if (isShaking)
        {
            //Debug.Log("speed: " + speed);
            float xVal = xPos + Mathf.Sin(Time.time * speed) * amount;
            amount = amount / 1.001f;

            if (amount < 0.05)
            {
                transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
                isShaking = false;
            }
            //Debug.Log(xVal);
            transform.position = new Vector3(xVal, transform.position.y, transform.position.z); 
            //Mathf.Sin(Time.time * speed) * amount;
        }
    }
}
