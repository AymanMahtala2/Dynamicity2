using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationController : MonoBehaviour
{
    public static NotificationController instance;

    public Transform content;

    public GameObject notificationItem;

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
        string newString = "+ ";
        GameObject obj = Instantiate(notificationItem, content);
        var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
        //var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
        //var itemAmount = obj.transform.Find("ItemAmount").GetComponent<TextMeshProUGUI>();

        newString += itemData.displayName;
        itemName.text = newString;
    }
}
