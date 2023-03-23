using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractorUI : MonoBehaviour
{
    public TMP_Text ItemNameText;

    private Vector3 ItemPosition;

    public void ShowItemName(Item item, Vector3 position)
    {
        ItemPosition = position;

        ItemNameText.text = item.ItemName;
        ItemNameText.enabled = true;
    }

    public void HideItemName()
    {
        ItemNameText.enabled = false;
    }

    public void Update()
    {
        UpdateItemNamePosition();
    }

    private void UpdateItemNamePosition()
    {
        ItemNameText.transform.position = Camera.main.WorldToScreenPoint(ItemPosition);
    }
}
