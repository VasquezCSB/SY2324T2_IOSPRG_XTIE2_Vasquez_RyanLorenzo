using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoLooting : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            Destroy(gameObject);
        }
    }
}
