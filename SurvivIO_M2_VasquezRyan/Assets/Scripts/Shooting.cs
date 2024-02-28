using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    public int 
        currentClip, 
        maxClipSize = 15, 
        currentAmmo, 
        maxAmmoSize = 90;

    [SerializeField] private Inventory bulletInventory;
    [SerializeField] private Transform shootingPosition;
    [SerializeField] private GameObject bulletPrefab;
    public TextMeshProUGUI clip;


    // Start is called before the first frame update
    void Start()
    {
        //mainCam = GameObject.FindGameObjectsWithTag("MainCamera").GetComponent<Camera>();
        clip.text = currentClip.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        clip.text = currentClip.ToString();
    }

    public void Fire()
    {
        if (currentClip > 0)
        {
            Instantiate(bulletPrefab, shootingPosition.position, shootingPosition.rotation);
            currentClip--;
        }

        //if (bulletInventory.baseBullet > 0)
        //{
        //    Instantiate(bulletPrefab, shootingPosition.position, shootingPosition.rotation);
        //    //GameObject bulletObj = (GameObject) Instantiate(bulletPrefab, this.transform.position + Vector3.up, Quaternion.identity);
        //}
    }


    //public void AddPistolAmmo(int ammoAmount)
    //{
    //    currentPistolAmmo += ammoAmount;
    //    if (currentPistolAmmo > maxPistolAmmoSize)
    //    {
    //        currentPistolAmmo = maxPistolAmmoSize;
    //    }
    //}

}
