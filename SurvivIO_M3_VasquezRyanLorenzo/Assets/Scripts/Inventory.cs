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
    public int maxClipSize_Shotgun = 2;
    public int currentAmmo_Shotgun;
    public int maxAmmoSize_Shotgun = 60;

    [Header("ClipAndReload_Automatic")]
    public int currentClip_Automatic;
    public int maxClipSize_Automatic = 30;
    public int currentAmmo_Automatic;
    public int maxAmmoSize_Automatic = 120;

    public Shooting shooting;

    //public GameObject[] primary;
    private GameObject secondary;

    public bool hasPistol = false;
    public bool hasShotgun = false;
    public bool hasAutomatic = false;


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
        //reloadClip_Pistol.text = pistolAmmo.ToString();
        //reloadClip_Shotgun.text = shotgunAmmo.ToString();
        //reloadClip_Automatic.text = automaticAmmo.ToString();

        //AddGunAmmo(pistolAmmo, maxAmmoSize);//Pistol
        //AddGunAmmo(shotgunAmmo, maxAmmoSize_Shotgun);
        //AddGunAmmo(automaticAmmo, maxAmmoSize_Automatic);
    }

    public void OverallReload()
    {

        if (hasPistol)
        {
            Debug.Log("Wayer2");
            StartCoroutine(GunReloadCoroutine(2, pistolAmmo, maxClipSize, currentClip, maxAmmoSize, clipCount_Pistol, reloadClip_Pistol));
        }
            
        else if (hasShotgun)
        {
            Debug.Log("AS");
            StartCoroutine(GunReloadCoroutine(2.3f, shotgunAmmo, maxClipSize_Shotgun, currentClip_Shotgun, maxAmmoSize_Shotgun, clipCount_Shotgun, reloadClip_Shotgun));
        }
            
        else if (hasAutomatic)
        {
            Debug.Log("Asjk");
            StartCoroutine(GunReloadCoroutine(2.7f, automaticAmmo, maxClipSize_Automatic, currentClip_Automatic, maxAmmoSize_Automatic, clipCount_Automatic, reloadClip_Automatic));
        }
            
    }

    public void AddGunAmmo(int gunAmmo, int gunMaxAmmoSize)
    {
        if (gunAmmo > gunMaxAmmoSize)
        {
            gunAmmo = gunMaxAmmoSize;
        }
    }

    private IEnumerator GunReloadCoroutine(float seconds, int gunAmmo, int gunMaxClipSize, int gunCurrentClip, int gunMaxAmmoSize, TextMeshProUGUI clipText, TextMeshProUGUI reloadText)
    {
        Debug.Log("VasquezBeginning:" + gunAmmo);
        yield return new WaitForSeconds(seconds);
        Debug.Log("Mask");
        if (gunAmmo > 0 && gunAmmo > gunMaxClipSize)
        {
            gunCurrentClip = gunMaxClipSize;
            gunAmmo -= gunMaxClipSize;
            Debug.Log("Pistol Ammo1 Alfred");

        }
        else if (gunAmmo > 0 && gunAmmo < gunMaxAmmoSize)
        {
            gunCurrentClip = gunAmmo;
            //Debug.Log(shooting.currentClip_Pistol);
            gunAmmo = 0;
            Debug.Log("Fire");
        }
        Debug.Log("VasquezEnding:" + gunAmmo);
        clipText.text = gunCurrentClip.ToString();
        reloadText.text = gunAmmo.ToString();
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
        if (hasAutomatic == true && hasShotgun == false)
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
