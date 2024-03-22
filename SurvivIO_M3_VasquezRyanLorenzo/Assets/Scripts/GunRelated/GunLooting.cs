using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLooting : MonoBehaviour
{

    //SerializeField] private GunTypes gunTypesVar;
    [SerializeField] private CurrentEquipWeapon weaponVar;
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
            if (weaponVar == CurrentEquipWeapon.pistol)
            {
                collision.GetComponent<Inventory>().ChangeSecondaryWeapon(weaponVar);
                //collision.GetComponent<Inventory>().hasPistol = true;
                //collision.GetComponent<Inventory>().setSecondary(true);

            }
            else if (weaponVar == CurrentEquipWeapon.shotgun || weaponVar == CurrentEquipWeapon.automatic)
            {
                collision.GetComponent<Inventory>().ChangePrimaryWeapon(weaponVar);

            }

            Destroy(gameObject);
        }
    }
}
