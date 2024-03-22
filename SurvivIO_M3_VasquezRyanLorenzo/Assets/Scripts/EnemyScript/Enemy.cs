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

    //[SerializeField] private GameObject slider;
    [SerializeField] private EnemyHealth enemyHealth;
    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        RandomSpawn();

        //curHealth = maxHealth;
        Debug.Log("curHealth: " + curHealth);

        //enemyHealth.GetComponent<EnemyHealth>().EnemyHealthBar(curHealth, maxHealth);
        //enemyHealth = GetComponentInChildren<EnemyHealth>();
        //enemyHealth.EnemyHealthBar(curHealth, maxHealth);
        
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
            EnemyDamage(collision.gameObject.GetComponent<BulletMovement>().damage);
        }
    }

    public void EnemyDamage(int damage)
    {
        curHealth -= damage;
        enemyHealth.EnemyHealthBar(curHealth, maxHealth);
        if(curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
