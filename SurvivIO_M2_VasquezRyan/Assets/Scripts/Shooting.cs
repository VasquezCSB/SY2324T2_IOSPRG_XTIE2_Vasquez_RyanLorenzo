using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //public GameObject bulletPrefab;
    [SerializeField] private Inventory bulletInventory;
    [SerializeField] private Transform shootingPosition;
    [SerializeField] private GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //mainCam = GameObject.FindGameObjectsWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        if (bulletInventory.baseBullet > 0)
        {
            Instantiate(bulletPrefab, shootingPosition.position, shootingPosition.rotation);
        }
    }
}
