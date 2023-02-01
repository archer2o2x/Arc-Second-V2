using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerWeaponUI : MonoBehaviour
{
    public TMP_Text AmmoText;
    public TMP_Text ReloadText;
    public Image StatusSprite;

    public string AmmoTemplate;
    public string ReloadTemplate;

    private Gun PlayerWeapon;

    // Start is called before the first frame update
    void Start()
    {
        PlayerWeapon = GameObject.FindGameObjectWithTag("Player").GetComponent<Gun>();

        StatusSprite.enabled = false;

        PlayerWeapon.OnGunFire.AddListener(UpdateAmmo);
        PlayerWeapon.OnGunReload.AddListener(UpdateReloads);
        PlayerWeapon.OnGunReady.AddListener(UpdateReady);

        Reset();
    }

    public void Reset()
    {
        AmmoText.text = AmmoTemplate.Replace("{AMMO}", PlayerWeapon.LeftInClip.ToString()).Replace("{MAX_AMMO}", PlayerWeapon.ClipSize.ToString());
        ReloadText.text = ReloadTemplate.Replace("{RELOADS}", PlayerWeapon.MaxReloads.ToString());
        StatusSprite.enabled = false;
    }

    public void UpdateAmmo()
    {
        AmmoText.text = AmmoTemplate.Replace("{AMMO}", PlayerWeapon.LeftInClip.ToString()).Replace("{MAX_AMMO}", PlayerWeapon.ClipSize.ToString());
        StatusSprite.enabled = true;
    }

    public void UpdateReloads()
    {
        StatusSprite.enabled = true;
    }

    public void UpdateReady()
    {
        StatusSprite.enabled = false;
        if (PlayerWeapon.GetGunState() == "RELOADING")
        {
            ReloadText.text = ReloadTemplate.Replace("{RELOADS}", PlayerWeapon.ReloadsLeft.ToString());
            UpdateAmmo();
        }
    }
}
