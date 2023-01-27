using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform GunTip;

    public float BulletDamage;
    public float BulletRange;

    public int ClipSize;
    public int MaxReloads;

    public float ChamberSpeed;
    public float ReloadSpeed;

    private int LeftInClip;
    private int ReloadsLeft;

    private float Timer = 0;

    public GameObject HitEffect;

    private void Start()
    {
        Reset();
    }

    private void Update()
    {
        Timer -= Time.deltaTime;

        Timer = Timer < 0 ? 0 : Timer;
    }

    public void Reset()
    {
        LeftInClip = ClipSize;
        ReloadsLeft = MaxReloads;

        Timer = 0;
    }

    public void Fire()
    {
        if (IsClipEmpty()) return;

        if (Timer > 0) return;

        RaycastHit info;

        LeftInClip--;

        Timer = ChamberSpeed;

        if (Physics.Raycast(GunTip.position, GunTip.forward, out info, BulletRange))
        {
            Health health = info.collider.gameObject.GetComponent<Health>();

            Instantiate(HitEffect, info.point, Quaternion.identity);

            if (health == null) return;

            health.Hurt(BulletDamage);
        }
    }

    public void Reload()
    {
        if (!IsReloadPossible()) return;

        if (Timer > 0) return;

        LeftInClip = ClipSize;

        Timer = ReloadSpeed;

    }

    public bool IsClipEmpty()
    {
        return LeftInClip == 0;
    }

    public bool IsReloadPossible()
    {
        return ReloadsLeft > 0;
    }
}
