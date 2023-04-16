using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MovingCharacter
{
    public static PlayerController instance;
    [SerializeField]
    private PlayerInput pi;
    private float horizontalInput;

    public List<MovingCharacter> enemiesToFight;
    public override void Attack()
    {
        animator.SetTrigger("Attack");
        weapon.Attack();
    }


    public override void Shield()
    {
        animator.SetBool("Defend", true);
    }

    public void LowerShield()
    {
        animator.SetBool("Defend", false);
    }

    public override void TakeDamage(int amount, Vector3 knockback)
    {

        health -= amount;
        if (health <= 0)
        {
            Die();
        }
        else
        {
            animator.SetTrigger("Hit");
            hit = true;
            rb.velocity = Vector2.zero;
            rb.AddForce(knockback, ForceMode2D.Impulse);
            Invoke("HitFalse", 0.5f);
        }
    }



    private void Start()
    {
        instance = this;
        speed = 5;
        health = 100;
    }
    private void Update()
    {

        direction = (int) pi.horizontalInput;
        //if(pi.attack)
        //{
        //    weapon.Attack();
        //}
 
    }

    public override void Die()
    {
        SceneManager.LoadScene(0);
    }
    [SerializeField]
    private float jumpVelocity = 10;
    public override void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
    }
}
