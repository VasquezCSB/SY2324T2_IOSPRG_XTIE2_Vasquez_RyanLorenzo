using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automatic : Gun
{
    public override void Fire(int ammo)
    {
        
        if (ammo > 0)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(bulletPrefab, shootingPosition.position, shootingPosition.rotation);
                bulletInventory.GetComponent<Inventory>().currentClip_Automatic--;
                ammo--;
            }

        }
    }
}
