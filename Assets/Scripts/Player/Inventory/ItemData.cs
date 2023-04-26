using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class ItemData : ScriptableObject
{
    public string displayName;
    public int amount;
    public int value;
    public ItemType itemType;
    public Sprite icon;

    public enum ItemType
    {
        Default,
        Potion
    }
}
