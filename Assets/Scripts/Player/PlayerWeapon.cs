using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Gun))]
public class PlayerWeapon : MonoBehaviour
{
    private Gun PlayerGun;

    public LayerMask NoShootLayers;

    public Transform GunTip;

    public float InteractDistance;

    public bool IsAuto;

    private void Start()
    {
        PlayerGun = GetComponent<Gun>();
    }

    public void OnFire(InputValue context)
    {
        if (context.isPressed) {

            if (CheckInteract()) return;

            PlayerGun.Fire();
            if (IsAuto) PlayerGun.OnGunReady.AddListener(PlayerGun.Fire);
        }
        if (!context.isPressed && IsAuto) {
            PlayerGun.OnGunReady.RemoveListener(PlayerGun.Fire);
        }
        
    }

    public bool CheckInteract()
    {
        RaycastHit info;

        if (Physics.Raycast(GunTip.position, GunTip.forward, out info, InteractDistance))
        {
            return NoShootLayers == (NoShootLayers | (1 << info.collider.gameObject.layer));
        }

        return false;
    }

    public void OnReload()
    {
        PlayerGun.Reload();
    }
}
