using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] ammoLoot;
    public GameObject[] gunLoot;
    public GameObject enemy;
    public GameObject playerTransform;

    public int totalLootAmount = 10;
    public int totalEnemies = 20;
    public int randomVar;

    public float spawnRadius = 100f; // The radius within which enemies can spawn around the player
    public float minDistanceFromPlayer = 10f; // The minimum distance enemies should spawn from the player
    public float minDistanceBetweenEnemies = 10f; // The minimum distance between spawned enemies

    public List<Transform> spawnedEnemies = new List<Transform>();
    public List<GameObject> spawnedAmmo = new List<GameObject>();
    public List<GameObject> spawnedWeapons = new List<GameObject>();



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
                SpawnGun();
            }

            //For ammo
            else if (randomVar >= 3 && randomVar <= 9)
            {
                SpawnAmmo();
            }
        }

        for (int i = 0; i <= totalEnemies - 1; i++)
        {
            SpawnEnemy();
        }
    }

    private void Update()
    {
        StartCoroutine(CheckForNullObjects());
    }

    void SpawnEnemy()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector2 spawnPosition = (Vector2)playerTransform.transform.position + randomDirection * minDistanceFromPlayer * 2;

        foreach (Transform enemy in spawnedEnemies)
        {
            if (Vector2.Distance(spawnPosition, enemy.position) < minDistanceBetweenEnemies)
            {
                // Adjust spawn position if it's too close to an existing enemy
                spawnPosition += (spawnPosition - (Vector2)enemy.position).normalized * minDistanceBetweenEnemies;
            }
        }

        // Spawn the enemy at the calculated position
        GameObject spawnedEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
        spawnedEnemy.transform.parent = this.transform;
        Transform newEnemy = spawnedEnemy.transform;
        spawnedEnemies.Add(newEnemy);

    }

    private void SpawnGun()
    {
        GameObject spawnedObject = Instantiate(gunLoot[Random.Range(0, ammoLoot.Length)], _randPos, Quaternion.identity);
        spawnedObject.transform.parent = this.transform;
        spawnedWeapons.Add(spawnedObject);
    }
    private void SpawnAmmo()
    {
        GameObject spawnedObject = Instantiate(ammoLoot[Random.Range(0, ammoLoot.Length)], _randPos, Quaternion.identity);
        spawnedObject.transform.parent = this.transform;
        spawnedAmmo.Add(spawnedObject);
    }

    private IEnumerator CheckForNullObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f); // Adjust the time interval as needed

            // Check each object in the list
            for (int i = 0; i < spawnedAmmo.Count; i++)
            {
                if (spawnedAmmo[i] == null)
                {
                    // Object is null, handle it (e.g., respawn or remove from the list)
                    spawnedAmmo.RemoveAt(i);
                    yield return new WaitForSeconds(1f);
                    SpawnAmmo();
                }
            }

            for (int i = 0; i < spawnedWeapons.Count; i++)
            {
                if (spawnedWeapons[i] == null)
                {
                    // Object is null, handle it (e.g., respawn or remove from the list)
                    spawnedWeapons.RemoveAt(i);
                    yield return new WaitForSeconds(1f);
                    SpawnGun();
                }
            }

            for (int i = 0; i < spawnedEnemies.Count; i++)
            {
                if (spawnedEnemies[i] == null)
                {
                    // Object is null, handle it (e.g., respawn or remove from the list)
                    spawnedEnemies.RemoveAt(i);
                    yield return new WaitForSeconds(1f);
                    SpawnEnemy();
                }
            }
        }
    }
}
