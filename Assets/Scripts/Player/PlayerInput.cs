using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float horizontalInput;
    public GameObject inventoryObject;
    public InventorySystem inventorySystem;

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown("i"))
        {
            if (!inventoryObject.activeSelf)
            {
                inventorySystem.ListItems();
            }
            inventoryObject.SetActive(!inventoryObject.activeSelf);
        }
    }
}
