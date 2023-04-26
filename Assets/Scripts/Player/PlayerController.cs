using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : Character
{
    public static PlayerController instance;

    private void Start()
    {
        instance = this;
    }

    public void OpenInventory()
    {

    }

    public override void Die()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        direction = (int)PlayerInput.instance.horizontalInput;
    }

    public override void FightingMode()
    {
        state = State.Fighting;
    }

    public void IdleMode()
    {
        state = State.Idle;
    }

    public void Talk()
    {
        if(di != null)
        {
            di.StartTalking();
        }
    }

    public void Jump()
    {

    }
}
