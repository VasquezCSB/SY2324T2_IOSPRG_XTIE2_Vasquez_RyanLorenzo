using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    [Header("Ammo Types")]
    public int pistolAmmo;
    public int shotgunAmmo;
    public int automaticAmmo;

    [Header("Gun Types")]
    public GameObject pistol;
    public GameObject shotgun;
    public GameObject automatic;

    [Header("Clip Count Text Vars")]
    public TextMeshProUGUI clipCount_Pistol;
    public TextMeshProUGUI clipCount_Shotgun;
    public TextMeshProUGUI clipCount_Automatic;
    public GameObject[] clipCountList;

    [Header("Reload Clip Text Vars")]
    public TextMeshProUGUI reloadClip_Pistol;
    public TextMeshProUGUI reloadClip_Shotgun;
    public TextMeshProUGUI reloadClip_Automatic;
    public GameObject[] reloadClipList;

    [Header("Weapon Switching")]
    [SerializeField] private int totalWeapons = 1;
    public int currentWeaponIndex;
    public GameObject[] guns;
    public GameObject weaponHolder;
    public GameObject currentGun;

    [Header("ClipAndReload")]
    public int currentClip;
    public int maxClipSize = 15;
    public int currentAmmo;
    public int maxAmmoSize = 90;

    [Header("ClipAndReload_Shotgun")]
    public int currentClip_Shotgun;
    public int maxClipSize_Shotgun = 30;
    public int currentAmmo_Shotgun;
    public int maxAmmoSize_Shotgun = 120;

    [Header("ClipAndReload_Automatic")]
    public int currentClip_Automatic;
    public int maxClipSize_Automatic = 2;
    public int currentAmmo_Automatic;
    public int maxAmmoSize_Automatic = 60;

    public Shooting shooting;

    //public GameObject[] primary;
    private GameObject secondary;

    public bool hasPistol = false;
    public bool hasShotgun = false;
    public bool hasAutomatic = false;


    // Start is called before the first frame update
    void Start()
    {
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

        reloadClip_Pistol.text = pistolAmmo.ToString();
        reloadClip_Shotgun.text = shotgunAmmo.ToString();
        reloadClip_Automatic.text = automaticAmmo.ToString();

        AddPistolAmmo();
        AddShotgunAmmo();
        AddAutomaticAmmo();
    }

    public void PistolReload()
    {
        StartCoroutine(PistolReloadCoroutine(2));
    }

    private IEnumerator PistolReloadCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        if (pistolAmmo > 0 && pistolAmmo > maxClipSize)
        {
            currentClip = maxClipSize;
            pistolAmmo -= maxClipSize;
            Debug.Log("Pistol Ammo1 Alfred");


        }
        else if (pistolAmmo > 0 && pistolAmmo < maxClipSize)
        {
            currentClip = pistolAmmo;
            //Debug.Log(shooting.currentClip_Pistol);
            pistolAmmo = 0;
        }
    }
    public void ShotgunReload()
    {
        StartCoroutine(ShotgunReloadCoroutine(2.3f));
    }

    private IEnumerator ShotgunReloadCoroutine(float seconds)
    {
        Debug.Log("Shotgun1 Ammo1 Alfred");

        yield return new WaitForSeconds(seconds);

        if (shotgunAmmo > 0 && shotgunAmmo > maxClipSize_Shotgun)
        {
            currentClip_Shotgun = maxClipSize_Shotgun;
            shotgunAmmo -= maxClipSize_Shotgun;
            Debug.Log("Shotgun Ammo1 Alfred");

        }
        else if (shotgunAmmo > 0 && shotgunAmmo < maxClipSize_Shotgun)
        {
            currentClip_Shotgun = shotgunAmmo;
            shotgunAmmo = 0;
        }
    }

    public void AutomaticReload()
    {
        StartCoroutine(AutomaticReloadCoroutine(2.7f));
    }

    private IEnumerator AutomaticReloadCoroutine(float seconds)
    {

        yield return new WaitForSeconds(seconds);

        if (automaticAmmo > 0 && automaticAmmo > maxClipSize_Automatic)
        {
            currentClip_Automatic = maxClipSize_Automatic;
            automaticAmmo -= maxClipSize_Automatic;

        }
        else if (automaticAmmo > 0 && automaticAmmo < maxClipSize_Automatic)
        {
            currentClip_Automatic = automaticAmmo;
            automaticAmmo = 0;
        }
    }

    //Increases reserve ammo
    public void AddPistolAmmo()
    {
        //currentPistolAmmo += ammoAmount;
        if (pistolAmmo > maxAmmoSize)
        {
            pistolAmmo = maxAmmoSize;
        }
    }

    //Increases reserve ammo
    public void AddShotgunAmmo()
    {
        //currentPistolAmmo += ammoAmount;
        if (shotgunAmmo > maxAmmoSize_Shotgun)
        {
            shotgunAmmo = maxAmmoSize_Shotgun;
        }
    }

    public void AddAutomaticAmmo()
    {
        //currentPistolAmmo += ammoAmount;
        if (automaticAmmo > maxAmmoSize_Automatic)
        {
            automaticAmmo = maxAmmoSize_Automatic;
        }
    }

    public void setSecondary(bool hasPistol)
    {
        if (hasPistol == true)
        {
            showPistol();
        }
    }

    public void setPrimary()
    {
        //For Shotgun
        if (hasShotgun == true && hasAutomatic == false)
        {
            showShotgun();
        }
        
        //For Automatic
        if(hasAutomatic == true && hasShotgun == false)
        {
            showAutomatic();
        }
    }

    public void showPistol()
    {
        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }
        guns[0].SetActive(true);
        currentGun = guns[0];
        currentWeaponIndex = 0;

        for (int i = 0; i < clipCountList.Length; i++)
        {
            clipCountList[i].SetActive(false);
        }
        clipCount_Pistol.gameObject.SetActive(true);
        clipCount_Pistol.text = currentClip.ToString();

        for (int i = 0; i < reloadClipList.Length; i++)
        {
            reloadClipList[i].SetActive(false);
        }
        reloadClip_Pistol.gameObject.SetActive(true);
        reloadClip_Pistol.text = pistolAmmo.ToString();
    }

    public void showShotgun()
    {
        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }
        guns[1].SetActive(true);
        currentGun = guns[1];
        currentWeaponIndex = 1;

        for (int i = 0; i < clipCountList.Length; i++)
        {
            clipCountList[i].SetActive(false);
        }
        clipCount_Shotgun.gameObject.SetActive(true);
        clipCount_Shotgun.text = currentClip_Shotgun.ToString();

        for (int i = 0; i < reloadClipList.Length; i++)
        {
            reloadClipList[i].SetActive(false);
        }
        reloadClip_Shotgun.gameObject.SetActive(true);
        reloadClip_Shotgun.text = shotgunAmmo.ToString();
    }

    public void showAutomatic()
    {
        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }
        guns[2].SetActive(true);
        currentGun = guns[2];
        currentWeaponIndex = 2;

        for (int i = 0; i < clipCountList.Length; i++)
        {
            clipCountList[i].SetActive(false);
        }

        clipCount_Automatic.gameObject.SetActive(true);
        clipCount_Automatic.text = currentClip_Automatic.ToString();

        for (int i = 0; i < reloadClipList.Length; i++)
        {
            reloadClipList[i].SetActive(false);
        }

        reloadClip_Automatic.gameObject.SetActive(true);
        reloadClip_Automatic.text = automaticAmmo.ToString();
    }
}
