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
    }

    public void OnGunFire()
    {
        PlayerGunAnimator.SetTrigger("Fire");
    }
}
