using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] ammoLoot;

    public GameObject[] gunLoot;

    public GameObject[] objectLoot;
    public int totalLootAmount = 10;
    public int randomVar;

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

            }else if(randomVar >= 3 && randomVar <= 9)
            {
                Debug.Log("Ammo");
                Instantiate(ammoLoot[Random.Range(0, ammoLoot.Length)], _randPos, Quaternion.identity);
            }

        }

    }
}
