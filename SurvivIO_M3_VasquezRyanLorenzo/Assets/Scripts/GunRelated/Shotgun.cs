using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField] private float offset;
    public int pellets = 8; // Number of pellets per shot
    public float spreadAngle = 30f; // Spread angle of pellets

    public override void Fire(int ammo)
    {
        if (ammo > 0)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                for (int i = 0; i < pellets; i++)
                {
                    Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(-spreadAngle, spreadAngle));
                    Instantiate(bulletPrefab, shootingPosition.position, shootingPosition.rotation * rotation);
                }
                bulletInventory.GetComponent<Inventory>().currentClip_Shotgun--;
                ammo--;
            }

        }
    }
}
