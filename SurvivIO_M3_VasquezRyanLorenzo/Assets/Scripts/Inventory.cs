using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    [Header("Script Reference")]
    public InterfaceManager interfaceManagerReference;


    [Header("Ammo Types")]
    public int pistolAmmo;
    public int shotgunAmmo;
    public int automaticAmmo;

    [Header("Gun Types")]
    public GameObject pistol;
    public GameObject shotgun;
    public GameObject automatic;

    //[Header("Clip Count Text Vars")]
    //public TextMeshProUGUI clipCount_Pistol;
    //public TextMeshProUGUI clipCount_Shotgun;
    //public TextMeshProUGUI clipCount_Automatic;
    public GameObject[] clipCountList;

    //[Header("Reload Clip Text Vars")]
    //public TextMeshProUGUI reloadClip_Pistol;
    //public TextMeshProUGUI reloadClip_Shotgun;
    //public TextMeshProUGUI reloadClip_Automatic;
    public GameObject[] reloadClipList;

    [Header("Weapon Switching")]
    [SerializeField] private int totalWeapons = 1;
    public GameObject[] guns;
    public GameObject weaponHolder;

    [Header("ClipAndReload")]
    public int currentClip;
    public int maxClipSize = 15;
    public int currentAmmo;
    public int maxAmmoSize = 90;

    [Header("ClipAndReload_Shotgun")]
    public int currentClip_Shotgun;
    public int maxClipSize_Shotgun = 2;
    public int currentAmmo_Shotgun;
    public int maxAmmoSize_Shotgun = 60;

    [Header("ClipAndReload_Automatic")]
    public int currentClip_Automatic;
    public int maxClipSize_Automatic = 30;
    public int currentAmmo_Automatic;
    public int maxAmmoSize_Automatic = 120;

    public Shooting shooting;
    public CurrentEquipWeapon currentEquipWeaponReference = CurrentEquipWeapon.unarmed;
    public CurrentEquipWeapon currentPrimaryWeapon = CurrentEquipWeapon.unarmed;
    public CurrentEquipWeapon currentSecondaryWeapon = CurrentEquipWeapon.unarmed;

    //public GameObject[] primary;
    private GameObject secondary;

    //public bool hasPistol = false;
    //public bool hasShotgun = false;
    //public bool hasAutomatic = false;


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("currentClip_Shotgun: " + currentClip_Shotgun);

        totalWeapons = weaponHolder.transform.childCount;
        guns = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("currentClip_Automatic: " + currentClip_Automatic);
        //reloadClip_Pistol.text = pistolAmmo.ToString();
        //reloadClip_Shotgun.text = shotgunAmmo.ToString();
        //reloadClip_Automatic.text = automaticAmmo.ToString();

    }

    public void PickUpAmmo(AmmoTypes typeAmmo, int ammoNum)
    {
        if (typeAmmo == AmmoTypes.pistolAmmo)
        {
            pistolAmmo += ammoNum;
            interfaceManagerReference.UpdatePistolAmmoUI(pistolAmmo);
        }
        else if (typeAmmo == AmmoTypes.shotgunAmmo)
        {
            shotgunAmmo += ammoNum;
            interfaceManagerReference.UpdateShotgunAmmoUI(shotgunAmmo);

        }
        else if (typeAmmo == AmmoTypes.automaticAmmo)
        {
            automaticAmmo += ammoNum;
            interfaceManagerReference.UpdateAutomaticAmmoUI(automaticAmmo);
        }
    }

    public void OverallReload()
    {
        if (currentEquipWeaponReference == CurrentEquipWeapon.pistol)
        {
            Debug.Log("Wayer2");
            StartCoroutine(GunReloadCoroutine(2, pistolAmmo, maxClipSize, currentClip, maxAmmoSize, 0));
        }
            
        else if (currentEquipWeaponReference == CurrentEquipWeapon.shotgun)
        {
            Debug.Log("AS");
            StartCoroutine(GunReloadCoroutine(2.3f, shotgunAmmo, maxClipSize_Shotgun, currentClip_Shotgun, maxAmmoSize_Shotgun, 1));
        }
            
        else if (currentEquipWeaponReference == CurrentEquipWeapon.automatic)
        {
            Debug.Log("Asjk");
            StartCoroutine(GunReloadCoroutine(2.7f, automaticAmmo, maxClipSize_Automatic, currentClip_Automatic, maxAmmoSize_Automatic, 2));
        }
            
    }

    public void AddGunAmmo(int gunAmmo, int gunMaxAmmoSize)
    {
        if (gunAmmo > gunMaxAmmoSize)
        {
            gunAmmo = gunMaxAmmoSize;
        }
    }

    private IEnumerator GunReloadCoroutine(float seconds, int gunAmmo, int gunMaxClipSize, int gunCurrentClip, int gunMaxAmmoSize, int gunIndex)
    {
        yield return new WaitForSeconds(seconds);
        if (gunAmmo > 0 && gunAmmo > gunMaxClipSize)
        {
            gunCurrentClip = gunMaxClipSize;
            gunAmmo -= gunMaxClipSize;
        }
        else if (gunAmmo > 0 && gunAmmo < gunMaxAmmoSize)
        {
            gunCurrentClip = gunAmmo;
            //Debug.Log(shooting.currentClip_Pistol);
            gunAmmo = 0;
        }

        if (gunIndex == 0)
        {
            pistolAmmo = gunAmmo;
            currentClip = gunCurrentClip;
            //clipText.text = gunCurrentClip.ToString();
            //reloadText.text = pistolAmmo.ToString();
            interfaceManagerReference.UpdatePistolAmmoUI(pistolAmmo);
        } else if(gunIndex == 1)
        {
            shotgunAmmo = gunAmmo;
            currentClip_Shotgun = gunCurrentClip;
            interfaceManagerReference.UpdateShotgunAmmoUI(shotgunAmmo);

            //clipText.text = gunCurrentClip.ToString();
            //reloadText.text = shotgunAmmo.ToString();

        }
        else if (gunIndex == 2)
        {
            automaticAmmo = gunAmmo;
            currentClip_Automatic = gunCurrentClip;
            interfaceManagerReference.UpdateAutomaticAmmoUI(automaticAmmo);
            //clipText.text = gunCurrentClip.ToString();
            //reloadText.text = automaticAmmo.ToString();
        }

        interfaceManagerReference.UpdateClipCount(gunCurrentClip);
    }
    public void ChangePrimaryWeapon(CurrentEquipWeapon weaponEquip)
    {
        currentPrimaryWeapon = weaponEquip;
        currentEquipWeaponReference = currentPrimaryWeapon;

        for (int i = 0; i < totalWeapons; i++)
        {
            //guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }

        if (currentEquipWeaponReference == CurrentEquipWeapon.shotgun)
        {
            guns[1].SetActive(true);
            interfaceManagerReference.UpdateClipCount(currentClip_Shotgun);
        } 
        else if (currentEquipWeaponReference == CurrentEquipWeapon.automatic)
        {
            guns[2].SetActive(true);
            interfaceManagerReference.UpdateClipCount(currentClip_Automatic);
            Debug.Log("currentClip_Automatic: " + currentClip_Automatic);
        }
    }

    public void ChangeSecondaryWeapon(CurrentEquipWeapon weaponEquip)
    {
        currentSecondaryWeapon = weaponEquip;
        currentEquipWeaponReference = currentSecondaryWeapon;

        for (int i = 0; i < totalWeapons; i++)
        {
            //guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }

        if (currentEquipWeaponReference == CurrentEquipWeapon.pistol)
        {
            guns[0].SetActive(true);
            interfaceManagerReference.UpdateClipCount(currentClip);
            Debug.Log("currentClip_Automatic: " + currentClip_Automatic);
        }
    }

    public void SwitchToPistol()
    {
        currentEquipWeaponReference = currentSecondaryWeapon;

        for (int i = 0; i < totalWeapons; i++)
        {
            //guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }

        if (currentEquipWeaponReference == CurrentEquipWeapon.pistol)
        {
            guns[0].SetActive(true);
            interfaceManagerReference.UpdateClipCount(currentClip);
            Debug.Log("currentClip_Automatic: " + currentClip_Automatic);

        }
    }

    public void SwitchToPrimary()
    {
       currentEquipWeaponReference = currentPrimaryWeapon;

        for (int i = 0; i < totalWeapons; i++)
        {
            //guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }

        if (currentEquipWeaponReference == CurrentEquipWeapon.shotgun)
        {
            guns[1].SetActive(true);
            interfaceManagerReference.UpdateClipCount(currentClip_Shotgun);
        }
        else if (currentEquipWeaponReference == CurrentEquipWeapon.automatic)
        {
            guns[2].SetActive(true);
            interfaceManagerReference.UpdateClipCount(currentClip_Automatic);
            Debug.Log("currentClip_Automatic: " + currentClip_Automatic);
        }
    }

    //public void setSecondary(bool hasPistol_)
    //{
    //    if (hasPistol_ == true)
    //    {
    //        showPistol();
    //    }

    //    hasPistol = true;
    //}

    //public void setPrimary()
    //{
    //    //For Shotgun
    //    if (hasShotgun == true && hasAutomatic == false)
    //    {
    //        showShotgun();
    //        hasPistol = false;
    //    }

    //    //For Automatic
    //    if (hasAutomatic == true && hasShotgun == false)
    //    {
    //        showAutomatic();
    //        hasPistol = false;
    //    }
    //}

    public void showPistol()
    {
        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }
        guns[0].SetActive(true);

        for (int i = 0; i < clipCountList.Length; i++)
        {
            clipCountList[i].SetActive(false);
        }
        //clipCount_Pistol.gameObject.SetActive(true);
        //clipCount_Pistol.text = currentClip.ToString();
    }

    public void showShotgun()
    {
        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }

        for (int i = 0; i < clipCountList.Length; i++)
        {
            clipCountList[i].SetActive(false);
        }
        //clipCount_Shotgun.gameObject.SetActive(true);
        //clipCount_Shotgun.text = currentClip_Shotgun.ToString();

    }

    public void showAutomatic()
    {
        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }

        for (int i = 0; i < clipCountList.Length; i++)
        {
            clipCountList[i].SetActive(false);
        }

        //clipCount_Automatic.gameObject.SetActive(true);
        //clipCount_Automatic.text = currentClip_Automatic.ToString();

    }
}
