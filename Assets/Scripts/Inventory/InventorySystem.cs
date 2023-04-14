using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem instance;
    public List<ItemData> items;

    public Transform itemContent;
    public GameObject inventoryItem;

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

    public void ListItems()
    {
        foreach (var item in items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMesh>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Sprite>();

            itemName.text = item.displayName;
            itemIcon = item.icon;
        }
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
