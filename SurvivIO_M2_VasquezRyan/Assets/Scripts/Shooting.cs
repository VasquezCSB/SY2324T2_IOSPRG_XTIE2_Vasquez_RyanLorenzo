using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Inventory bulletInventory;
    [SerializeField] private Pistol pistol;
    [SerializeField] private Shotgun shotgun;
    [SerializeField] private Automatic automatic;

    public TextMeshProUGUI clip_Pistol;
    public TextMeshProUGUI clip_Shotgun;
    public TextMeshProUGUI clip_Automatic;

    // Start is called before the first frame update
    void Start()
    {
        //mainCam = GameObject.FindGameObjectsWithTag("MainCamera").GetComponent<Camera>();

        //clip_Pistol.text = currentClip_Pistol.ToString();
        clip_Pistol.text = bulletInventory.GetComponent<Inventory>().currentClip.ToString();
        clip_Shotgun.text = bulletInventory.GetComponent<Inventory>().currentClip_Shotgun.ToString();
        clip_Automatic.text = bulletInventory.GetComponent<Inventory>().currentClip_Automatic.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        //clip_Pistol.text = currentClip_Pistol.ToString();
        clip_Pistol.text = bulletInventory.GetComponent<Inventory>().currentClip.ToString();
        clip_Shotgun.text = bulletInventory.GetComponent<Inventory>().currentClip_Shotgun.ToString();
        clip_Automatic.text = bulletInventory.GetComponent<Inventory>().currentClip_Automatic.ToString();
    }

    public void Fire()
    {
        if (bulletInventory.GetComponent<Inventory>().hasPistol)
        {
            Debug.Log("PistolFire");
            pistol.Fire(bulletInventory.GetComponent<Inventory>().currentClip);
        }

        if (bulletInventory.GetComponent<Inventory>().hasShotgun)
        {
            Debug.Log("ShotgunFire");
            shotgun.Fire(bulletInventory.GetComponent<Inventory>().currentClip_Shotgun);
        }

        if (bulletInventory.GetComponent<Inventory>().hasAutomatic)
        {
            Debug.Log("AutomaticFire");
            automatic.Fire(bulletInventory.GetComponent<Inventory>().currentClip_Automatic);
        }
    }

    public void Reload()
    {
        if (bulletInventory.GetComponent<Inventory>().hasPistol)
        {
            bulletInventory.GetComponent<Inventory>().PistolReload();
        }
        
        if (bulletInventory.GetComponent<Inventory>().hasShotgun)
        {
            bulletInventory.GetComponent<Inventory>().ShotgunReload();

        }
        
        if (bulletInventory.GetComponent<Inventory>().hasAutomatic)
        {
            bulletInventory.GetComponent<Inventory>().AutomaticReload();

        }
    }
}
