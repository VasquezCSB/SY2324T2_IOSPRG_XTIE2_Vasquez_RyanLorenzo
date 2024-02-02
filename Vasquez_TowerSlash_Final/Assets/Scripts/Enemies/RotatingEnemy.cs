//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingEnemy : MonoBehaviour
{
    //public GameObject[] arrows;
    public bool isPlayerInRange = false;
    public bool isDone = false;

    public EnemyDirection enemy;
    [SerializeField] private  EnemyChecker enemyChecker;
    public static float degrees;
    float newDegrees = 90;
    public Renderer m_Renderer;

    public GameObject yellowArrow;
    public int[] setArray;
    public int randomVal;

    // Start is called before the first frame update
    void Start()
    {
        //noCollision = false;
        enemyChecker = EnemyChecker.instance.gameObject.GetComponent<EnemyChecker>();
        StartCoroutine(rotationSwitch());
        setArray = new int[4] { 0, 1, 2, 3 };
    }


    void Update()
    {
        if (isPlayerInRange == true && isDone == false)
        {
            Invoke(nameof(Randomization), 0.0005f);
            isDone = true;
        }

    }

    IEnumerator rotationSwitch()//bool noCollision
    {
        //Keeps on running until there is yield or return;

        //use only yellow 

        //isPlayerInRange if you enter CharAttackArea you need to terminate the loop

        // you only one switcher for the active object
        // use only one child object to rotate

        while (isPlayerInRange == false)         
        {
           degrees += newDegrees;
           yellowArrow.transform.eulerAngles = Vector3.forward * degrees;
           yield return new WaitForSeconds(0.5f);

        }
        //inform the user what is the final arrow that he need to swipe
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isPlayerInRange = true;
    }

    void Randomization()
    {
        if (isPlayerInRange == true)
        {
            randomVal = Random.Range(0, setArray.Length);
            Direction(randomVal);
        }
    }

    void Direction(int random)
    {
        if(random == 0)
        {
            enemy = EnemyDirection.Left;
            enemyChecker.enemy = enemy;

            yellowArrow.transform.eulerAngles = new Vector3(0,0,0);
            m_Renderer.material.color = Color.green;

            Debug.Log("this is Left");
        }
        else if(random == 1)
        {
            enemy = EnemyDirection.Right;
            enemyChecker.enemy = enemy;
            //enemyScript.thisEnemyDirection = enemy;
            yellowArrow.transform.eulerAngles = new Vector3(0,0, -180);
            m_Renderer.material.color = Color.green;

            Debug.Log("this is Right");
        }
        else if (random == 2)
        {
            enemy = EnemyDirection.Up;
            enemyChecker.enemy = enemy;
            yellowArrow.transform.eulerAngles = new Vector3(0, 0, -90);
            m_Renderer.material.color = Color.green;

            //enemyScript.thisEnemyDirection = enemy;
            Debug.Log("this is Up");
        }
        else if (random == 3)
        {
            enemy = EnemyDirection.Down;
            enemyChecker.enemy = enemy;
            //enemyScript.thisEnemyDirection = enemy;
            yellowArrow.transform.eulerAngles = new Vector3(0, 0, -270);
            m_Renderer.material.color = Color.green;

            Debug.Log("this is Down");
        }
    }

}
