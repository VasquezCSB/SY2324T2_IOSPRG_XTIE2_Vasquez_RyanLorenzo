using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    public static EnemyChecker instance;
    //public GameObject boxThatEntered;
    public EnemyDirection enemy;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks what is up,down,left,right
        if (collision.gameObject.GetComponent<EnemyScript>() != null)
        {
            if (collision.gameObject.GetComponent<EnemyScript>().thisEnemyDirection == EnemyDirection.Up)
            {
                enemy = EnemyDirection.Up;
                Debug.Log("Up");
            }
            else if (collision.gameObject.GetComponent<EnemyScript>().thisEnemyDirection == EnemyDirection.Down)
            {
                enemy = EnemyDirection.Down;
                Debug.Log("Down");

            }
            else if (collision.gameObject.GetComponent<EnemyScript>().thisEnemyDirection == EnemyDirection.Left)
            {
                enemy = EnemyDirection.Left;
                Debug.Log("Left");

            }
            else if (collision.gameObject.GetComponent<EnemyScript>().thisEnemyDirection == EnemyDirection.Right)
            {
                enemy = EnemyDirection.Right;
                Debug.Log("Right");

            }

        }
    }

}
