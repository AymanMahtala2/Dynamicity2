using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ItemData itemData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            Pickup();
    }

    void Pickup()
    {
        InventorySystem.instance.Add(itemData);
        Destroy(gameObject);
    }

    public void UseItem()
    {
        Debug.Log(itemData.displayName);
    }
}
