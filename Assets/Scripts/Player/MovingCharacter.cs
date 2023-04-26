using Cinemachine;
using UnityEngine;

public abstract class MovingCharacter : MonoBehaviour
{
    [SerializeField]
    protected int health = 100;
    [SerializeField]
    protected int armor;

    [SerializeField]
    protected Rigidbody2D rb;
    [SerializeField]
    protected float speed;
    [SerializeField]
    public int direction;

    public int stamina = 50;
    protected bool blocking;

    public Animator animator;

    [SerializeField]
    public Weapon weapon;

    public bool hit;

    public bool dead;

    public bool fightingMode;

    public AISurrounding surrounding;

    [SerializeField]
    protected Collider2D bodyCollider;


    private void FixedUpdate()
    {
        if(!hit)
        {
            MoveCharacter();
            animator.SetFloat("Speed", rb.velocity.magnitude);
        }
    }

    private void MoveCharacter()
    {
        if(!hit)
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        Flip();
    }

    private void Flip()
    {
        if(!hit && !fightingMode)
            if (rb.velocity.x > 0)
            {
                transform.localScale = new Vector3(-1, 1);
            }
            else if (rb.velocity.x < 0)
            {
                transform.localScale = new Vector3(1, 1);
            }
    }

    public abstract void Attack();

    public abstract void Shield();

    public abstract void TakeDamage(int amount, Vector3 knockback);

    protected void HitFalse()
    {
        hit = false;
    }

    public abstract void Die();

    public abstract void Jump();
}
