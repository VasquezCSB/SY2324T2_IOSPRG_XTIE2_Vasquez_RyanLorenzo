using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoLooting : MonoBehaviour
{
    [SerializeField] private AmmoTypes ammoTypesVar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            AmmoLoot(out int ammoSize);
            collision.GetComponent<Inventory>().PickUpAmmo(ammoTypesVar, ammoSize);
            Destroy(gameObject);
        }
    }

    private void AmmoLoot(out int ammoTypeSize)
    {
        if (ammoTypesVar == AmmoTypes.pistolAmmo)
            ammoTypeSize = Random.Range(1, 8);
        else if (ammoTypesVar == AmmoTypes.shotgunAmmo)
            ammoTypeSize = Random.Range(1, 2);
        else
            ammoTypeSize = Random.Range(5, 15);

    }
}
