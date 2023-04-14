using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MovingCharacter
{

    private void Start()
    {
        health = 100;
        speed = 2;
    }

    public override void Attack()
    {
        animator.SetTrigger("Attack");
        weapon.Attack();
    }

    public override void Shield()
    {
        throw new System.NotImplementedException();
    }

    public override void TakeDamage(int amount, Vector3 knockback)
    {
        if(!fightingMode)
        {
            vcam.Priority = 11;
            PlayerController.instance.fightingMode = true;
            fightingMode = true;
            gameObject.AddComponent(typeof(AIEnemy));
        }
        health -= amount;
        if(health <= 0)
        {
            AudioController.instance.PlaySFX(2);
            Die();
        } else
        {
            animator.SetTrigger("Hit");
            AudioController.instance.PlaySFX(Random.Range(0, 2));
            hit = true;
            rb.velocity = Vector2.zero;
            rb.AddForce(knockback, ForceMode2D.Impulse);
            Invoke("HitFalse", 0.5f);
        }

    }
    public override void Die()
    {
        vcam.Priority = 1;
        PlayerController.instance.fightingMode = false;
        AudioController.instance.StopMusic();
        animator.SetTrigger("Die");
        dead = true;
        Destroy(GetComponent<AIEnemy>());
        rb.bodyType = RigidbodyType2D.Static;
        bodyCollider.enabled = false;
        Destroy(this);
    }

    public override void Jump()
    {
        throw new System.NotImplementedException();
    }
}
