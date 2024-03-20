using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] ammoLoot;
    public GameObject[] gunLoot;
    public GameObject[] objectLoot;
    public GameObject enemy;
    public GameObject playerTransform;

    public int totalLootAmount = 10;
    public int totalEnemies = 20;
    public int randomVar;

    public float spawnRadius = 100f; // The radius within which enemies can spawn around the player
    public float minDistanceFromPlayer = 10f; // The minimum distance enemies should spawn from the player
    public float minDistanceBetweenEnemies = 10f; // The minimum distance between spawned enemies
    public List<Transform> spawnedEnemies = new List<Transform>();


    //Coords for Spawning
    private float _randomX;
    private float _randomY;
    private Vector3 _randPos;

    private void Start()
    {
        for (int i = 0; i <= totalLootAmount - 1; i++)
        {
            randomVar = Random.Range(0, totalLootAmount);

            //Gets Random Position of instance
            _randomX = Random.Range(-45, 45);
            _randomY = Random.Range(-11, 11);
            _randPos = new Vector3(_randomX, _randomY, 0);

            if (randomVar >= 0 && randomVar <= 2)
            {
                Debug.Log("Gun");
                Instantiate(gunLoot[Random.Range(0, ammoLoot.Length)], _randPos, Quaternion.identity);

            }
            else if (randomVar >= 3 && randomVar <= 9)
            {
                Debug.Log("Ammo");
                Instantiate(ammoLoot[Random.Range(0, ammoLoot.Length)], _randPos, Quaternion.identity);
            }

        }


        for (int i = 0; i <= totalEnemies - 1; i++)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector2 spawnPosition = (Vector2)playerTransform.transform.position + randomDirection * minDistanceFromPlayer * 10;

        foreach (Transform enemy in spawnedEnemies)
        {
            if (Vector2.Distance(spawnPosition, enemy.position) < minDistanceBetweenEnemies)
            {
                // Adjust spawn position if it's too close to an existing enemy
                spawnPosition += (spawnPosition - (Vector2)enemy.position).normalized * minDistanceBetweenEnemies;
            }
        }

        // Spawn the enemy at the calculated position
        Transform newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity).transform;
        spawnedEnemies.Add(newEnemy);

    }
}
