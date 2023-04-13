using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class MovingCharacter : MonoBehaviour
{
    [SerializeField]
    protected Rigidbody2D rb;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int direction;

    private void Update()
    {
        //horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        MoveCharacter();
        GetComponent<Animator>().SetFloat("Speed", rb.velocity.magnitude);
    }

    private void MoveCharacter()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        Flip();
    }

    private void Flip()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(-1, 1);
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(1, 1);
        }
    }
}
