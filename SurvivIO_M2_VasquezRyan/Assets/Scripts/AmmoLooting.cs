using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoLooting : MonoBehaviour
{
    [SerializeField] private AmmoTypes ammoTypesVar;
    [SerializeField] private int ammoSize;

    private void Start()
    {
        ammoSize = Random.Range(10, 20);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            if(ammoTypesVar == AmmoTypes.pistolAmmo)
            {
                collision.GetComponent<Inventory>().pistolAmmo += ammoSize;

            } else if(ammoTypesVar == AmmoTypes.shotgunAmmo)
            {
                collision.GetComponent<Inventory>().shotgunAmmo += ammoSize;
            }
            else if (ammoTypesVar == AmmoTypes.automaticAmmo)
            {
                collision.GetComponent<Inventory>().automaticAmmo += ammoSize;
            }

            Destroy(gameObject);
        }
    }
}
