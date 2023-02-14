using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimator : MonoBehaviour
{
    public Animator PlayerGunAnimator;

    public Gun PlayerWeapon;

    private void Start()
    {
        PlayerGunAnimator.SetFloat("Fire Speed", 1 / PlayerWeapon.ChamberSpeed);
        PlayerGunAnimator.SetFloat("Reload Speed", 1 / PlayerWeapon.ReloadSpeed);
    }

    public void OnGunFire()
    {
        PlayerGunAnimator.SetTrigger("Fire");
    }

    public void OnGunReload()
    {
        PlayerGunAnimator.SetBool("Reloading", true);
        PlayerWeapon.OnGunReady.AddListener(OnGunReady);
    }

    public void OnGunReady()
    {
        PlayerGunAnimator.SetBool("Reloading", false);
        PlayerWeapon.OnGunReady.RemoveListener(OnGunReady);
    }
}
