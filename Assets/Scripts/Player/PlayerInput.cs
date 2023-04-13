using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float horizontalInput;
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }
}
