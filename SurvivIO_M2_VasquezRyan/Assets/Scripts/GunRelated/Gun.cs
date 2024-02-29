using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    [SerializeField] protected Inventory bulletInventory;
    [SerializeField] protected Shooting shooting;
    [SerializeField] protected Transform shootingPosition;
    [SerializeField] protected GameObject bulletPrefab;

    [SerializeField] protected float fireRate;
    protected float nextFire;

    //public static Shooting instance;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public virtual void Fire(int ammo)
    {
        if (ammo > 0)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(bulletPrefab, shootingPosition.position, shootingPosition.rotation);
                bulletInventory.GetComponent<Inventory>().currentClip--;
            }
            
        }
    }
}
