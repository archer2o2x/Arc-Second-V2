using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public ItemRecord[] ItemRegistry;

    public GameObject GetItemFromID(string ItemID)
    {
        foreach (ItemRecord obj in ItemRegistry)
        {
            if (obj.ItemID != ItemID) continue;

            return obj.ItemObject;
        }

        return null;
    }

    public string GetNameFromID(string ItemID)
    {
        foreach (ItemRecord obj in ItemRegistry)
        {
            if (obj.ItemID != ItemID) continue;

            return obj.ItemName;
        }

        return null;
    }

    public void AddItem(string ItemID, int amount, Vector3 position, Quaternion rotation)
    {
        GameObject obj = Instantiate(GetItemFromID(ItemID), position, rotation);

        Item newItem = obj.AddComponent<Item>();
        newItem.ItemID = ItemID;
        newItem.ItemName = GetNameFromID(ItemID);
        newItem.ItemAmount = amount;
    }

    public static ItemManager Self
    {
        get
        {
            return GameObject.FindGameObjectWithTag("GameController").GetComponent<ItemManager>();
        }
    }
}

[System.Serializable]
public struct ItemRecord
{
    public string ItemID;
    public string ItemName;
    public GameObject ItemObject;
}
