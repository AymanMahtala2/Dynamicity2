using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField]
    protected int health = 100;
    [SerializeField]
    protected int armor;

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    public int direction;

    public int stamina = 50;

    public Animator animator;

    public bool hit;

    public bool fightingMode;

    public bool canBeDamaged;

    public bool canMove;
    private void FixedUpdate()
    {
        if (!hit)
        {
            MoveCharacter();
            animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        }
    }

    private void Update()
    {
        direction = (int) PlayerInput.instance.horizontalInput;
    }

    private void MoveCharacter()
    {
        if (!hit && canMove)
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        Flip();
    }

    private void Flip()
    {
        if (!hit && !fightingMode)
            if (rb.velocity.x > 0)
            {
                transform.localScale = new Vector3(-1, 1);
            }
            else if (rb.velocity.x < 0)
            {
                transform.localScale = new Vector3(1, 1);
            }
    }

    public void TakeDamage(int amount, Vector3 knockback)
    {
        if(canBeDamaged)
        {
            health -= amount;
        } else
        {
            stamina -= amount;
            if (stamina <= 0)
            {
                //stunned for 2 seconds
            }
            else
            {
                AudioController.instance.PlaySFX(4);
                //rb.velocity = Vector2.zero;
                //PlayerInput.instance.CannotMoveOrAttack(0.75f);
                rb.AddForce(Vector2.left * 10, ForceMode2D.Impulse);
            }
        }


    }

    protected void HitFalse()
    {
        hit = false;
    }
    [SerializeField]
    private float jumpVelocity = 10;
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }


    public void Shield()
    {
        rb.velocity = Vector2.zero;
        animator.SetBool("Defend", true);
        DeactivateDamage();
    }

    public void LowerShield()
    {
        animator.SetBool("Defend", false);
        ActivateDamage();
    }
    public void DeactivateDamage()
    {
        canBeDamaged = false;
    }

    public void ActivateDamage()
    {
        canBeDamaged = true;
    }
}
