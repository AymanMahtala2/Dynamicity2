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

    public int NPCNumber;

    public bool isDrunkMan;
    public Dialogue dialogueDrunkCompleted;

    public bool Rendall;
    public Dialogue dialogueKilledThiefNoStartQuest;
    public Dialogue dialogueKilledThief;

    protected void Start()
    {
        if (isDrunkMan)
        {
            GameManager.instance.drunkman = this;
            GameManager.instance.dialogueDrunkCompleted = dialogueDrunkCompleted;
        }
        if (Rendall)
        {
            GameManager.instance.Rendall = this;
            GameManager.instance.dialogueKilledThief = dialogueKilledThief;
            GameManager.instance.dialogueKilledThiefNoStartQuest = dialogueKilledThiefNoStartQuest;
            Debug.Log("here");
            if (GameManager.instance.QuestGuide[2] == GameManager.QuestState.SucceededWithoutStarting)
            {
                di.dialogue = dialogueKilledThiefNoStartQuest;
                Debug.Log("here2");

            }
            else if (GameManager.instance.QuestGuide[2] == GameManager.QuestState.Step2)
            {
                di.dialogue = dialogueKilledThief;
                Debug.Log("here3");

            }

        }
    }


    private void FixedUpdate()
    {
        if (state == State.Idle)
        {
            MoveCharacter();
        } else if(state == State.Fighting)
        {
            MoveCharacterInFight();
        }
        //animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        if (rb.velocity.magnitude > 0.1f)
        {
            ChangeAnimationState("walk");
        }
        else
        {
            ChangeAnimationState("idle");
        }
    }

    private void MoveCharacter()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        Flip();
    }

    public void SetAnimationToNull()
    {
        currentState = "";
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
        ChangeAnimationState("attack");
    }
    public void AttackCollider()
    {
        weapon.Attack();
        Invoke("SetAnimationToNull", 1);
    }
    public void EndAttack()
    {
        weapon.EndAttack();
        currentState = "";
    }

    public void Shield()
    {
        canMove = false;
        shield.RaiseShield();
        rb.velocity = Vector2.zero;
        ChangeAnimationState("shield");
        DeactivateDamage();

    }

    public void LowerShield()
    {
        canMove = true;
        shield.LowerShield();
        ChangeAnimationState("shield");
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
        ChangeAnimationState("die");
        dead = true;
        Destroy(GetComponent<AIEnemy>());
        Destroy(GetComponent<Collider2D>());
        rb.bodyType = RigidbodyType2D.Static;
        GameManager.instance.LogDeath(NPCNumber, GameManager.State.Dead);
        Destroy(di.gameObject);
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
                ChangeAnimationState("hurt");
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
    public string currentState;
    public void ChangeAnimationState(string newState)
    {
        if(newState == "die" || newState == "")
        {
            animator.Play(newState);

            currentState = newState;
        }

        if (currentState == newState || currentState == "attack" || currentState == "hurt")
        {
            return;
        }

        animator.Play(newState);

        currentState = newState;


        //if (CanInterruptAnimation(newState))
        //{
        //    animator.Play(newState);

        //    currentState = newState;
        //} else
        //{
        //    if (currentState == newState) return;

        //    animator.Play(newState);

        //    currentState = newState;
        //}
    }

    private bool CanInterruptAnimation(string incomingAnimation)
    {
        if(incomingAnimation == "hurt" || incomingAnimation == "die")
        {
            return true;
        }
        return false;
    }

    protected enum State
    {
        Idle, //or "exploring" for the PC
        Fighting,
        Running,
        Dead
    }
}
