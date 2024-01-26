using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform enemySpawnPoint; 
    public GameObject[] enemyList;

    private void Start() { 
        StartCoroutine(SpawnEnemyEveryTwoSeconds()); 
    }

    //Coroutine for spawning enemies
    private IEnumerator SpawnEnemyEveryTwoSeconds() { 
        SpawnEnemy(); 
        yield return new WaitForSeconds(2f); 

        while (true) { 
            SpawnEnemy(); 
            yield return new WaitForSeconds(2f); 
        } 

    }

    //Enemy Spawn Function
    private void SpawnEnemy() {
        Instantiate(enemyList[Random.Range(0, enemyList.Length)], 
            enemySpawnPoint.position, Quaternion.identity); 

    }
}
