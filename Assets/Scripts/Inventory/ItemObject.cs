using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ItemData itemData;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Pickup();
    }

    void Pickup()
    {
        Debug.Log("hihaho");
        InventorySystem.instance.Add(itemData);
        Destroy(gameObject);
    }
}
