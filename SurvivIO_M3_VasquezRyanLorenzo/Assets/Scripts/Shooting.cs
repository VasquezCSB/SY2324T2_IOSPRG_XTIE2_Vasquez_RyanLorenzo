using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Shooting : MonoBehaviour
{
    public TextMeshProUGUI clip_Pistol;
    public TextMeshProUGUI clip_Shotgun;
    public TextMeshProUGUI clip_Automatic;
    public InterfaceManager interfaceManagerReference;
    public GameObject bulletPrefab;

    public float longPressDuration = 1f; // Duration in seconds for a long press
    private bool isPressed = false;
    private float fireRate;

    [SerializeField] private Inventory bulletInventory;
    [SerializeField] private Pistol pistol;
    [SerializeField] private Shotgun shotgun;
    [SerializeField] private Automatic automatic;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isPressed)
        {
            Fire();
        } 

    }

    public void DownPress()
    {
        isPressed = true;
    }

    public void UpPress()
    {
        isPressed = false;

    }

    private IEnumerator FireContinuously()
    {
        while (isPressed)
        {
            Fire();
            yield return null;
        }
    }

    public void Fire()
    {
        isPressed = true;

        if (bulletInventory.GetComponent<Inventory>().currentEquipWeaponReference == CurrentEquipWeapon.pistol)
        {
            pistol.Fire(bulletInventory.GetComponent<Inventory>().currentClip);
            interfaceManagerReference.UpdateClipCount(bulletInventory.GetComponent<Inventory>().currentClip);
            bulletPrefab.GetComponent<BulletMovement>().damage = 10;
        }

        if (bulletInventory.GetComponent<Inventory>().currentEquipWeaponReference == CurrentEquipWeapon.shotgun)
        {
            Debug.Log("ShotgunFire");
            shotgun.Fire(bulletInventory.GetComponent<Inventory>().currentClip_Shotgun);
            interfaceManagerReference.UpdateClipCount(bulletInventory.GetComponent<Inventory>().currentClip_Shotgun);
            bulletPrefab.GetComponent<BulletMovement>().damage = 10;
        }

        if (bulletInventory.GetComponent<Inventory>().currentEquipWeaponReference == CurrentEquipWeapon.automatic && isPressed == true)
        {
            Debug.Log("AutomaticFire");
            automatic.Fire(bulletInventory.GetComponent<Inventory>().currentClip_Automatic);
            interfaceManagerReference.UpdateClipCount(bulletInventory.GetComponent<Inventory>().currentClip_Automatic);
            bulletPrefab.GetComponent<BulletMovement>().damage = 15;
        }
    }

    public void Reload()
    {
        Debug.Log("Wayer");
        bulletInventory.GetComponent<Inventory>().OverallReload();
    }
}
