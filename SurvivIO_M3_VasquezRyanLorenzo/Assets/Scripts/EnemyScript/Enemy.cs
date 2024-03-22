using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Unit
{
    public Transform Target { get; set; }
    public GameObject[] randomWeaponSpawn;
    public int randomWeaponSpawnNum;

    public EnemyTypes enemyTypes;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        RandomSpawn();

        //curHealth = maxHealth;
        Debug.Log("curHealth: " + curHealth);

        
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<BulletMovement>() != null)
        {
            Destroy(collision.gameObject);
            this.GetComponent<HealthComponent>().TakeDamage(collision.gameObject.GetComponent<BulletMovement>().damage);
            //EnemyDamage(collision.gameObject.GetComponent<BulletMovement>().damage);
        }
    }
}
