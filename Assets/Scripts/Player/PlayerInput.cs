using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour
{
    public float horizontalInput;
    public bool attack;
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if(Input.GetMouseButtonDown(0))
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

    public void TriggerAttack()
    {

    }
}
