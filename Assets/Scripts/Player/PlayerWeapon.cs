using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Gun))]
public class PlayerWeapon : MonoBehaviour
{
    private Gun PlayerGun;

    public bool IsAuto;

    private void Start()
    {
        PlayerGun = GetComponent<Gun>();
    }

    public void OnFire(InputValue context)
    {
        if (context.isPressed) {
            PlayerGun.Fire();
            if (IsAuto) PlayerGun.OnGunReady.AddListener(PlayerGun.Fire);
        }
        if (!context.isPressed && IsAuto) {
            PlayerGun.OnGunReady.RemoveListener(PlayerGun.Fire);
        }
        
    }

    public void OnReload()
    {
        PlayerGun.Reload();
    }
}
