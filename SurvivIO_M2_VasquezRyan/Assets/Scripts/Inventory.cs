using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    [Header("Ammo Types")]
    public int 
        pistolAmmo,
        shotgunAmmo,
        automaticAmmo;

    [Header("Gun Types")]
    public GameObject 
        pistol, 
        shotgun, 
        automatic;

    public TextMeshProUGUI reloadClip;
    public Shooting shooting;
    //public AmmoLooting looting;

    public int maxPistolAmmoSize = 90;

    // Start is called before the first frame update
    void Start()
    {
        reloadClip.text = pistolAmmo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Invoke(nameof(PistolInvoke), 0.0005f);
        reloadClip.text = pistolAmmo.ToString();
        AddPistolAmmo();  

        //shooting.currentAmmo = pistolAmmo;
        //reloadClip.text = shooting.currentAmmo.ToString();

        //clip.text = shooting.currentClip.ToString();

    }

    public void PistolReload()
    {
        
        if (pistolAmmo > 0 && pistolAmmo > shooting.maxClipSize)
        {
            shooting.currentClip = shooting.maxClipSize;
            pistolAmmo -= shooting.maxClipSize;
            
        } 
        else if (pistolAmmo > 0 && pistolAmmo < shooting.maxClipSize)
        {
            shooting.currentClip = pistolAmmo;
            pistolAmmo = 0;
        }

        
        //int reloadAmount = maxClipSize - currentClip;
        //reloadAmount = (bulletInventory.pistolAmmo - reloadAmount) >= 0 ? reloadAmount : bulletInventory.pistolAmmo;
        //currentClip += reloadAmount;
        //currentAmmo -= reloadAmount;
    }

    //Increases reserve ammo
    public void AddPistolAmmo()
    {
        //currentPistolAmmo += ammoAmount;
        if (pistolAmmo > maxPistolAmmoSize)
        {
            pistolAmmo = maxPistolAmmoSize;
        }
    }
}
