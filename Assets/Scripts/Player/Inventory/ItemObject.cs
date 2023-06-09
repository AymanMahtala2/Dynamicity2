using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ItemData itemData;
    public bool isKey;
    public bool isJournal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            Pickup();
    }

    void Pickup()
    {
        InventorySystem.instance.Add(itemData);
        if(isKey)
        {
            GameManager.instance.OpenDoor();
            GameManager.instance.LogQuest(1, GameManager.QuestState.Succeeded);
        }
        if (isJournal)
        {
            PlayerController.instance.hasJournal = true;
        }
        Destroy(gameObject);
    }

    public void UseItem()
    {
        Debug.Log(itemData.displayName);
    }
}
