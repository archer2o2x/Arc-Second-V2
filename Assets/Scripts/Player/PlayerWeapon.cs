using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Gun))]
public class PlayerWeapon : MonoBehaviour
{
    private Gun PlayerGun;

    private void Start()
    {
        PlayerGun = GetComponent<Gun>();
    }

    public void OnFire()
    {
        PlayerGun.Fire();
    }

    public void OnReload()
    {
        PlayerGun.Reload();
    }
}
