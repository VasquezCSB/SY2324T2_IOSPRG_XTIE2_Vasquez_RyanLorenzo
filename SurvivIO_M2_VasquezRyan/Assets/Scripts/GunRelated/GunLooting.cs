using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLooting : MonoBehaviour
{

    [SerializeField] private GunTypes gunTypesVar;
    //public Shooting shooting;

    private void Start()
    {
        //shooting = Shooting.instance.gameObject.GetComponent<Shooting>();
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            if (gunTypesVar == GunTypes.pistol)
            {
                collision.GetComponent<Inventory>().hasPistol = true;
                collision.GetComponent<Inventory>().setSecondary(true);

            }
            else if (gunTypesVar == GunTypes.shotgun)
            {
                collision.GetComponent<Inventory>().hasShotgun = true;
                collision.GetComponent<Inventory>().hasAutomatic = false;
                collision.GetComponent<Inventory>().setPrimary();


            }
            else if (gunTypesVar == GunTypes.automatic)
            {
                collision.GetComponent<Inventory>().hasAutomatic = true;
                collision.GetComponent<Inventory>().hasShotgun = false;
                collision.GetComponent<Inventory>().setPrimary();

            }

            Destroy(gameObject);
        }
    }
}
