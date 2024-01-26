using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingEnemy : MonoBehaviour
{
    //public GameObject[] arrows;
    public bool noCollision = true;
    public EnemyDirection enemy;
    public bool isRotating = true;
    int degrees;

    // Start is called before the first frame update
    void Start()
    {
        //noCollision = false;
        //StartCoroutine(rotationSwitch());
    }
    IEnumerator rotationSwitch()//bool noCollision
    {
        if(isRotating == true)
        {
            degrees = 90;
            transform.eulerAngles = Vector3.forward * degrees;
            yield break;

        }

        ////Keeps on running until there is yield or return;
        //while(true)
        //{
        //    //Left
        //    arrows[0].SetActive(true);
        //    yield return new WaitForSeconds(1f);
        //    arrows[0].SetActive(false);
        //    enemy = EnemyDirection.Left;

        //    //Right
        //    arrows[1].SetActive(true);
        //    yield return new WaitForSeconds(1f);
        //    arrows[1].SetActive(false);
        //    enemy = EnemyDirection.Right;

        //    //Right
        //    arrows[2].SetActive(true);
        //    yield return new WaitForSeconds(1f);
        //    arrows[2].SetActive(false);
        //    enemy = EnemyDirection.Right;

        //    //Left
        //    arrows[3].SetActive(true);
        //    yield return new WaitForSeconds(1f);
        //    arrows[3].SetActive(false);
        //    enemy = EnemyDirection.Left;

        //    //Up
        //    arrows[4].SetActive(true);
        //    yield return new WaitForSeconds(1f);
        //    arrows[4].SetActive(false);
        //    enemy = EnemyDirection.Up;

        //    //Up
        //    arrows[5].SetActive(true);
        //    yield return new WaitForSeconds(1f);
        //    arrows[5].SetActive(false);
        //    enemy = EnemyDirection.Up;

        //    //Down
        //    arrows[6].SetActive(true);
        //    yield return new WaitForSeconds(1f);
        //    arrows[6].SetActive(false);
        //    enemy = EnemyDirection.Down;

        //    //Down
        //    arrows[7].SetActive(true);
        //    yield return new WaitForSeconds(1f);
        //    arrows[7].SetActive(false);
        //    enemy = EnemyDirection.Down;

        //}


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StopCoroutine();
    }

    void StopCoroutine()
    {
        StopCoroutine(rotationSwitch());
    }

}
