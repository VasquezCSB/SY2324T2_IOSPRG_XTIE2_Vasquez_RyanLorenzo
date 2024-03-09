using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    public Transform Target { get; set; }
    public GameObject[] randomWeaponSpawn;
    public int randomWeaponSpawnNum;

    // Start is called before the first frame update
    void Start()
    {
        RandomSpawn();
    }

    private void RandomSpawn()
    {
        randomWeaponSpawnNum = Random.Range(0, randomWeaponSpawn.Length);

        if (randomWeaponSpawnNum == 0)
        {
            randomWeaponSpawn[0].SetActive(true);
        }
        else if (randomWeaponSpawnNum == 1)
        {
            randomWeaponSpawn[1].SetActive(true);
        }
        else if (randomWeaponSpawnNum == 2)
        {
            randomWeaponSpawn[2].SetActive(true);
        }
    }
}
