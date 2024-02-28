using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLooting : MonoBehaviour
{
    [SerializeField] private GunTypes gunTypesVar;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            if (gunTypesVar == GunTypes.pistol)
            {
                collision.GetComponent<Inventory>().pistol.SetActive(true);
                collision.GetComponent<Inventory>().shotgun.SetActive(false);
                collision.GetComponent<Inventory>().automatic.SetActive(false);
            }
            else if (gunTypesVar == GunTypes.shotgun)
            {
                collision.GetComponent<Inventory>().pistol.SetActive(false);
                collision.GetComponent<Inventory>().shotgun.SetActive(true);
                collision.GetComponent<Inventory>().automatic.SetActive(false);
            }
            else if (gunTypesVar == GunTypes.automatic)
            {
                collision.GetComponent<Inventory>().pistol.SetActive(false);
                collision.GetComponent<Inventory>().shotgun.SetActive(false);
                collision.GetComponent<Inventory>().automatic.SetActive(true);
            }

            Destroy(gameObject);
        }
    }
}
