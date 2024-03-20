using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    public Transform Target { get; set; }
    public GameObject[] randomWeaponSpawn;
    public int randomWeaponSpawnNum;

    public EnemyTypes enemyTypes;

    // Start is called before the first frame update
    void Start()
    {
        RandomSpawn();
    }

    private void RandomSpawn()
    {
        randomWeaponSpawnNum = Random.Range(0, randomWeaponSpawn.Length);

        if (randomWeaponSpawnNum == 0) //Pistol
        {
            randomWeaponSpawn[0].SetActive(true);
            enemyTypes = EnemyTypes.pistolEnemy;
        }
        else if (randomWeaponSpawnNum == 1) //Shotgun
        {
            randomWeaponSpawn[1].SetActive(true);
            enemyTypes = EnemyTypes.shotgunEnemy;
        }
        else if (randomWeaponSpawnNum == 2) //Automatic
        {
            randomWeaponSpawn[2].SetActive(true);
            enemyTypes = EnemyTypes.automaticEnemy;
        }
    }
}
