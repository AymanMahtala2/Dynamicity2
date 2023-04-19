using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour
{
    public static PlayerInput instance;
    public float horizontalInput;
    public bool attack;

    public bool canMove;
    public bool canAttack;

    private void Start()
    {
        instance = this;
        canMove = true;
        canAttack = true;
    }
    private void Update()
    {
        if(canMove)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
        }
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            PlayerController.instance.Attack();
        }
        if (Input.GetMouseButtonDown(1))
        {
            PlayerController.instance.Shield();
        }
        if (Input.GetMouseButtonUp(1))
        {
            PlayerController.instance.LowerShield();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerController.instance.Jump();
        }
    }

    public void CannotMoveOrAttack()
    {
        canMove = false;
        canAttack = false;
    }

    public void CannotMoveOrAttack(float time)
    {
        canMove = false;
        canAttack = false;
        Invoke("CanMoveOrAttack", time);
    }

    public void CanMoveOrAttack()
    {
        canMove = true;
        canAttack = true;
    }

    public void TriggerAttack()
    {

    }
}
