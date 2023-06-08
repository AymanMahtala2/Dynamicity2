using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    public ItemObject droppable;
    public int health;

    //shaking object
    protected float defaultSineWidth = 0.07f;
    protected float sineSpeed = 23f;
    protected float sineFrequency = 1.01f;
    protected float sineCutOff = 0.05f;
    protected float spawnHeight = 1;

    protected float xPos;
    protected bool isHit = false;

    private bool isAnimating = false;
    private float sineWidth;

    void Start()
    {
        sineWidth = defaultSineWidth;
    }

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
        if (health <= 0)
        {
            Die();
        }
        else
        {
            this.Animate();
        }
    }

    public virtual void Die()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        DropItem();
        Destroy(this);
    }

    public void DropItem()
    {
        if (droppable != null)
        {
            ItemObject item = Instantiate(droppable);
            item.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + spawnHeight, transform.position.z);
            item.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 3, 0), ForceMode2D.Impulse);

        }
        else
        {
            Debug.Log("DestructibleObject: no droppable assigned");
        }
    }

    public virtual void Animate()
    {
        xPos = transform.position.x;
        sineWidth = defaultSineWidth;
        isAnimating = true;
    }

    public void FixedUpdate()
    {
        if (isAnimating)
        {
            float xVal = xPos + Mathf.Sin(Time.time * sineSpeed) * sineWidth;
            sineWidth = sineWidth / sineFrequency;

            if (sineWidth < sineCutOff)
            {
                transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
                isHit = false;
                isAnimating = false;
            }
            transform.position = new Vector3(xVal, transform.position.y, transform.position.z);
        }
    }
}
