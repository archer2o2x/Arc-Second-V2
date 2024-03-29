using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public Transform GunTip;

    public float InteractDistance;

    public PlayerToolbelt Toolbelt;

    public PlayerInteractorUI Visualiser;

    void OnInteract()
    {
        RaycastHit info;

        if (Physics.Raycast(GunTip.position, GunTip.forward, out info, InteractDistance))
        {
            if (info.collider.gameObject.tag != "Interactable") return;

            Item ItemObj = info.collider.GetComponent<Item>();
            if (ItemObj != null)
            {
                Toolbelt.TryPickupItem(ItemObj);
            }
        }
    }

    void Update()
    {
        RaycastHit info;

        if (Physics.Raycast(GunTip.position, GunTip.forward, out info, InteractDistance))
        {
            if (info.collider.gameObject.tag != "Interactable") return;

            Item ItemObj = info.collider.GetComponent<Item>();
            if (ItemObj != null)
            {
                Visualiser.ShowItemName(ItemObj, info.collider.transform.position);
                return;
            }
        }
        Visualiser.HideItemName();
    }
}
