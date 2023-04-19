using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        foreach (ItemData item in items)
        {
            if (itemData == item)
            {
                item.amount++;
                return;
            }
        }
        itemData.amount = 1;
        items.Add(itemData);
    }

    public void Remove(ItemData itemData)
    {
        items.Remove(itemData);
    }

    public void ListItems()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in items)
        {
            //Creates new itemObject into intemcontent parent
            GameObject obj = Instantiate(inventoryItem, itemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var itemAmount = obj.transform.Find("ItemAmount").GetComponent<TextMeshProUGUI>();

            itemName.text = item.displayName;
            itemIcon.sprite = item.icon;
            itemAmount.text = item.amount.ToString();
        }
    }
}
