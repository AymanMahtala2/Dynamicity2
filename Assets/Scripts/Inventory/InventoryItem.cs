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

    public void UseItem()
    {
        switch (itemData.itemType)
        {
            case ItemData.ItemType.Potion:
                Debug.Log("issa potion with value: " + itemData.value);
                break;
            default:
                break;
        }
    }
}
