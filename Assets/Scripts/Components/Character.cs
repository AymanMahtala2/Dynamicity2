using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Character : MonoBehaviour
{
    public int health = 100;
    public int stamina = 50;
    [SerializeField]
    protected Rigidbody2D rb;
    [SerializeField]
    protected float speed = 4;
    [SerializeField]
    public int direction;

    public Animator animator;

    [SerializeField] private Body body;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Shield shield;

    public bool dead;
    protected State state;

    [SerializeField]
    public DialogueInstigator di;

    private bool canMove = true;
    private bool canBeDamaged = true;
    private void FixedUpdate()
    {
        if (state == State.Idle)
        {
            MoveCharacter();
        } else if(state == State.Fighting)
        {
            MoveCharacterInFight();
        }
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    private void MoveCharacter()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        Flip();
    }

    private void MoveCharacterInFight()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }
    [SerializeField]
    private int faceDirection; //1 = right, -1 = left
    private void Flip()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(-1, 1);
            faceDirection = 1;
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(1, 1);
            faceDirection = -1;
        }
    }
    public bool attacking;
    public void Attack()
    {
        weapon.Attack();
        animator.SetTrigger("Attack");
    }

    public void Shield()
    {
        canMove = false;
        shield.RaiseShield();
        rb.velocity = Vector2.zero;
        animator.SetBool("Defend", true);
        DeactivateDamage();

    }

    public void LowerShield()
    {
        canMove = true;
        shield.LowerShield();
        animator.SetBool("Defend", false);
        ActivateDamage();
    }

    public virtual void FightingMode()
    {
        state = State.Fighting;
        gameObject.AddComponent<AIEnemy>();
    }

    public virtual void Die()
    {
        AudioController.instance.PlaySFX(2);
        animator.SetTrigger("Die");
        dead = true;
        Destroy(GetComponent<AIEnemy>());
        Destroy(GetComponent<Collider2D>());
        rb.bodyType = RigidbodyType2D.Static;
        BattleManager.instance.KilledEnemy();
        //collider false
        Destroy(this);
    }

    public virtual void TakeDamage(int amount, float knockback)
    {
        if(state == State.Idle)
        {
            FightingMode();
        }
        if(canBeDamaged)
        {
            health -= amount;
            if(health <= 0)
            {
                Die();
            } else
            {
                animator.SetTrigger("Hit");
                AudioController.instance.PlaySFX(0);
                rb.AddForce(Vector2.left * knockback * 100 * faceDirection, ForceMode2D.Impulse);
            }
        } else
        {
            stamina -= amount;
            AudioController.instance.PlaySFX(4);
            rb.AddForce(Vector2.left * knockback * faceDirection, ForceMode2D.Impulse);
        }

    }

    public void DeactivateDamage()
    {
        canBeDamaged = false;
    }

    public void ActivateDamage()
    {
        canBeDamaged = true;
    }

    protected enum State
    {
        Idle, //or "exploring" for the PC
        Fighting,
        Running,
        Dead
    }
}
