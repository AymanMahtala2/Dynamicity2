using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem instance;
    public List<ItemData> items;

    private void Start()
    {
        instance = this;
    }

    private void Awake()
    {
        instance = this;
    }

    public void Add(ItemData itemData)
    {
        items.Add(itemData);
    }

    public void Remove(ItemData itemData)
    {
        items.Remove(itemData);
    }

    //private Dictionary<InventoryItemData, InventoryItem> itemDictionary;
    //public List<InventoryItem> inventory { get; private set; }

    //private void Awake()
    //{
    //    inventory = new List<InventoryItem>();
    //    itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    //}

    //private void Update()
    //{

    //}
}
