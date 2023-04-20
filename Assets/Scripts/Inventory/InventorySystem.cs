using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem instance;
    public List<ItemData> itemsData;

    public Transform itemContent;
    public GameObject inventoryItem;

    public InventoryItem[] inventoryItems;

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
        foreach (ItemData item in itemsData)
        {
            if (itemData == item)
            {
                item.amount++;
                return;
            }
        }
        itemData.amount = 1;
        itemsData.Add(itemData);
    }

    public void Remove(ItemData itemData)
    {
        itemsData.Remove(itemData);
    }

    public void ListItems()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in itemsData)
        {
            //Creates new itemObject into itemcontent parent
            GameObject obj = Instantiate(inventoryItem, itemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var itemAmount = obj.transform.Find("ItemAmount").GetComponent<TextMeshProUGUI>();

            itemName.text = item.displayName;
            itemIcon.sprite = item.icon;
            itemAmount.text = item.amount.ToString();
        }

        SetInventoryItems();
    }

    public void SetInventoryItems()
    {
        inventoryItems = itemContent.GetComponentsInChildren<InventoryItem>();

        for (int i = 0; i < itemsData.Count; i++)
        {
            inventoryItems[i].AddItem(itemsData[i]);
        }
    }

    public void Clean()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
    }
}
