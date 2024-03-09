using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoLooting : MonoBehaviour
{
    //public int randomPistolAmmoSize;

    [SerializeField] private AmmoTypes ammoTypesVar;
    [SerializeField] private int randomPistolAmmoSize;
    [SerializeField] private int randomShotgunAmmoSize;
    [SerializeField] private int randomAutomaticAmmoSize;

    private void Start()
    {
        //ammoSize = Random.Range(10, 20);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            if(ammoTypesVar == AmmoTypes.pistolAmmo)
            {
                AmmoLoot(ref randomPistolAmmoSize, 1, 8);
                collision.GetComponent<Inventory>().pistolAmmo += randomPistolAmmoSize;
                Debug.Log("PistolLoot: " + collision.GetComponent<Inventory>().pistolAmmo);

            } else if(ammoTypesVar == AmmoTypes.shotgunAmmo)
            {
                AmmoLoot(ref randomShotgunAmmoSize, 1, 2);
                collision.GetComponent<Inventory>().shotgunAmmo += randomShotgunAmmoSize;
                Debug.Log("ShotgunLoot: " + collision.GetComponent<Inventory>().shotgunAmmo);
            }
            else if (ammoTypesVar == AmmoTypes.automaticAmmo)
            {
                AmmoLoot(ref randomAutomaticAmmoSize, 5,15);
                collision.GetComponent<Inventory>().automaticAmmo += randomAutomaticAmmoSize;
            }

            Destroy(gameObject);
        }
    }

    public void AmmoLoot(ref int ammoTypeSize, int minAmmo, int maxAmmo)
    {
        ammoTypeSize = Random.Range(minAmmo, maxAmmo);
    }
}
