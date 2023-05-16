using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    private float speed = 23f; //how fast it shakes
    private float amount = 0.08f; //how much it shakes
    private bool isShaking = false;
    private float xPos;

    public void GetHit()
    {
        if (!isShaking)
        {
            Debug.Log("tree is hit");
            xPos = transform.position.x;
            amount = 0.08f;
        }
        isShaking = true;
    }

    public void Update()
    {
        if (isShaking)
        {
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
