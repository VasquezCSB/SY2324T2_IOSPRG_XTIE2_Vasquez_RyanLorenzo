using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SwipeResult : MonoBehaviour
{
    [SerializeField] private EnemyChecker enemyChecker;
    [SerializeField] private SwipeControls swipeControl;

    [SerializeField] private List<GameObject> Enemies;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (swipeControl.hasSwipedRight == true && enemyChecker.enemy == EnemyDirection.Right && Enemies[0] != null)
        {
            GameObject ToDestroy = Enemies[Enemies.Count - 1];
            Destroy(ToDestroy);
            Enemies.RemoveAt(Enemies.Count - 1);

            swipeControl.hasSwipedRight = false;

        } else if (swipeControl.hasSwipedLeft == true && enemyChecker.enemy == EnemyDirection.Left && Enemies[0] != null)
        {
            GameObject ToDestroy = Enemies[Enemies.Count - 1];
            Destroy(ToDestroy);
            Enemies.RemoveAt(Enemies.Count - 1);

            swipeControl.hasSwipedLeft = false;

        } else if (swipeControl.hasSwipedUp == true && enemyChecker.enemy == EnemyDirection.Up && Enemies[0] != null)
        {
            GameObject ToDestroy = Enemies[Enemies.Count - 1];
            Destroy(ToDestroy);
            Enemies.RemoveAt(Enemies.Count - 1);

            swipeControl.hasSwipedUp = false;

        } else if (swipeControl.hasSwipedDown == true && enemyChecker.enemy == EnemyDirection.Down && Enemies[0] != null)
        {
            GameObject ToDestroy = Enemies[Enemies.Count - 1];
            Destroy(ToDestroy);
            Enemies.RemoveAt(Enemies.Count - 1);

            swipeControl.hasSwipedDown = false;

        }

        if (Enemies[0] == null)
        {
            Enemies.RemoveAll(Enemies => !Enemies);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemyChecker.enemy == EnemyDirection.Right && collision.gameObject.GetComponent<EnemyScript>() != null 
            || enemyChecker.enemy == EnemyDirection.Left && collision.gameObject.GetComponent<EnemyScript>() != null
            || enemyChecker.enemy == EnemyDirection.Up && collision.gameObject.GetComponent<EnemyScript>() != null
            || enemyChecker.enemy == EnemyDirection.Down && collision.gameObject.GetComponent<EnemyScript>() != null)
        {
            Enemies.Add(collision.gameObject);
        }

    }
}
