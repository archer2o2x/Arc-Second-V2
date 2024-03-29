using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    public Transform GunTip;
    public Transform CosmeticGunTip;

    public float BulletDamage;
    public float BulletRange;

    public int ClipSize;
    public int MaxReloads;

    public float ChamberSpeed;
    public float ReloadSpeed;

    public int LeftInClip { get { return _LeftInClip; } }
    public int ReloadsLeft { get { return _ReloadsLeft; } }

    private int _LeftInClip;
    private int _ReloadsLeft;

    private float Timer = 0;
    private string State = "IDLE";

    public GameObject HitEffect;
    public GameObject LineEffect;

    public UnityEvent OnGunFire;
    public UnityEvent OnGunReload;
    public UnityEvent OnGunReady;

    public LayerMask NoShootLayers;

    private void Start()
    {
        Reset();
    }

    private void Update()
    {
        Timer -= Time.deltaTime;

        //Timer = Timer < 0 ? 0 : Timer;
        if (Timer <= 0)
        {
            Timer = 0;
            OnGunReady.Invoke();
            State = "IDLE";
        }
    }

    public void Reset()
    {
        _LeftInClip = ClipSize;
        _ReloadsLeft = MaxReloads;

        Timer = 0;
        State = "IDLE";
    }

    public void Fire()
    {
        if (IsClipEmpty()) return;

        if (Timer > 0) return;

        RaycastHit info;

        _LeftInClip--;

        State = "CHAMBERING";

        Timer = ChamberSpeed;

        OnGunFire.Invoke();

        if (Physics.Raycast(GunTip.position, GunTip.forward, out info, BulletRange))
        {


            Debug.Log(info.collider.gameObject.layer);

            Health health = info.collider.gameObject.GetComponent<Health>();

            Instantiate(HitEffect, info.point, Quaternion.identity);
            Instantiate(LineEffect, info.point, Quaternion.identity).GetComponent<BulletLine>().Setup(CosmeticGunTip.position, info.point);

            if (health == null) return;

            health.Hurt(BulletDamage);
        } else
        {
            Instantiate(LineEffect, GunTip.forward * BulletRange + GunTip.position, Quaternion.identity).GetComponent<BulletLine>().Setup(CosmeticGunTip.position, GunTip.position + GunTip.forward * BulletRange);
        }
    }

    public void Reload()
    {
        if (!IsReloadPossible()) return;

        if (Timer > 0) return;

        _LeftInClip = ClipSize;

        _ReloadsLeft--;

        State = "RELOADING";

        Timer = ReloadSpeed;

        OnGunReload.Invoke();
    }

    public bool IsClipEmpty()
    {
        return _LeftInClip == 0;
    }

    public bool IsReloadPossible()
    {
        return _ReloadsLeft > 0;
    }

    public string GetGunState()
    {
        return State;
    }
}
