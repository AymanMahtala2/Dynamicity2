using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public ItemData itemData;

    public void AddItem(ItemData itemData)
    {
        this.itemData = itemData;
    }
    public void DoSomething()
    {
        //InventorySystem.instance

        Debug.Log(itemData);
    }
}
