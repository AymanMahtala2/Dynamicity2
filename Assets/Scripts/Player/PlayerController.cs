using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MovingCharacter
{
    [SerializeField]
    private PlayerInput pi;
    private float horizontalInput;

    private void Start()
    {
        speed = 5;
    }
    private void Update()
    {

        direction = (int) pi.horizontalInput;
    }

}
