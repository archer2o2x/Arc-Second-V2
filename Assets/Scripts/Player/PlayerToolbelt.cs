using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToolbelt : MonoBehaviour
{
    public Dictionary<string, int> Inventory;

    private void Start()
    {
        Inventory = new Dictionary<string, int>();
    }

    public void TryPickupItem(Item item)
    {
        if (Inventory.ContainsKey(item.ItemID)) Inventory[item.ItemID] = Inventory[item.ItemID] + item.ItemAmount;
        else Inventory[item.ItemID] = item.ItemAmount;

        Destroy(item.gameObject);
    }

    public bool CanUseItem(string ItemID, int amount)
    {
        if (!Inventory.ContainsKey(ItemID)) return false;

        if (Inventory[ItemID] < amount) return false;

        return true;
    }

    public bool TryUseItem(string ItemID, int amount)
    {
        if (!CanUseItem(ItemID, amount)) return false;

        Inventory[ItemID] -= amount;

        return true;
    }

    [ContextMenu("List Inventory Contents")]
    public void DisplayContents()
    {
        foreach (var key in Inventory.Keys)
        {
            Debug.Log("    " + Inventory[key].ToString().PadRight(4) + " X " + key);
        }
    }
}
