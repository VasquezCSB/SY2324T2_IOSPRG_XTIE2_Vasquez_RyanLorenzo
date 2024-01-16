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
        if (swipeControl.hasSwipedRight == true && Enemies[0] != null)
        {
            GameObject ToDestroy = Enemies[Enemies.Count - 1];
            Destroy(ToDestroy);
            Enemies.RemoveAt(Enemies.Count - 1);

            swipeControl.hasSwipedRight = false;

        } else if (swipeControl.hasSwipedLeft == true && Enemies[0] != null)
        {
            GameObject ToDestroy = Enemies[Enemies.Count - 1];
            Destroy(ToDestroy);
            Enemies.RemoveAt(Enemies.Count - 1);

            swipeControl.hasSwipedLeft = false;

        } else if (swipeControl.hasSwipedUp == true && Enemies[0] != null)
        {
            GameObject ToDestroy = Enemies[Enemies.Count - 1];
            Destroy(ToDestroy);
            Enemies.RemoveAt(Enemies.Count - 1);

            swipeControl.hasSwipedUp = false;

        } else if (swipeControl.hasSwipedDown == true && Enemies[0] != null)
        {
            GameObject ToDestroy = Enemies[Enemies.Count - 1];
            Destroy(ToDestroy);
            Enemies.RemoveAt(Enemies.Count - 1);

            swipeControl.hasSwipedDown = false;

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
