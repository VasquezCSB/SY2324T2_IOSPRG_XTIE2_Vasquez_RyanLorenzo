using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    public override void Fire(int ammo)
    {
        if (ammo > 0)
        {
            Debug.Log("Alfred");
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(bulletPrefab, shootingPosition.position, shootingPosition.rotation);
                bulletInventory.GetComponent<Inventory>().currentClip--;
                ammo--;
            }

        }
    }
}
