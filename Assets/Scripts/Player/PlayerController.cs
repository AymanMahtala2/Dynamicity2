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

    [SerializeField]
    private CinemachineTargetGroup swordCam;

    public List<MovingCharacter> enemiesToFight;
    public override void Attack()
    {
        if (Random.Range(0, 4) == 2)
        {
            Invoke("ActionCam", 0.25f);
        }
        animator.SetTrigger("Attack");
        weapon.Attack();
    }

    private void ActionCam()
    {
        swordCam.m_Targets[0].radius = 0.5f;
        swordCam.m_Targets[1].radius = 0.75f;
        Time.timeScale = 0.5f;
        Invoke("NormalCam", 1.25f);
    }

    private void NormalCam()
    {
        swordCam.m_Targets[0].radius = 1f;
        swordCam.m_Targets[1].radius = 1.5f;
        Time.timeScale = 1f;
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
