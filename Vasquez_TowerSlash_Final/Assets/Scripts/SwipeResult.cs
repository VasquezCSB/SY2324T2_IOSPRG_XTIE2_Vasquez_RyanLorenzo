using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SwipeResult : MonoBehaviour
{
    [SerializeField] private EnemyChecker enemyChecker;
    [SerializeField] private SwipeControls swipeControl;

    [SerializeField] public List<GameObject> Enemies;
    [SerializeField] private GameManager gameManager;

    public bool isSwiped = false;

    // Start is called before the first frame update
    void Start()
    {
        //enemyChecker = EnemyChecker.instance.gameObject.GetComponent<EnemyChecker>();
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
            gameManager.AddDashMeter();
            gameManager.RandomForPowerUp();
            gameManager.Score();

        } else if (swipeControl.hasSwipedRight == true && enemyChecker.enemy != EnemyDirection.Right && isSwiped == false)
        {
            isSwiped = true;
            Invoke(nameof(NewFunction_Right), 0.0005f);
        }

        if (swipeControl.hasSwipedLeft == true && enemyChecker.enemy == EnemyDirection.Left && Enemies[0] != null)
        {
            GameObject ToDestroy = Enemies[Enemies.Count - 1];
            Destroy(ToDestroy);
            Enemies.RemoveAt(Enemies.Count - 1);

            swipeControl.hasSwipedLeft = false;
            gameManager.AddDashMeter();
            gameManager.RandomForPowerUp();
            gameManager.Score();
        }
        else if (swipeControl.hasSwipedLeft == true && enemyChecker.enemy != EnemyDirection.Left && isSwiped == false)
        {
            isSwiped = true;
            Invoke(nameof(NewFunction_left), 0.0005f);
        }

        if (swipeControl.hasSwipedUp == true && enemyChecker.enemy == EnemyDirection.Up && Enemies[0] != null)
        {
            GameObject ToDestroy = Enemies[Enemies.Count - 1];
            Destroy(ToDestroy);
            Enemies.RemoveAt(Enemies.Count - 1);

            swipeControl.hasSwipedUp = false;
            gameManager.AddDashMeter();
            gameManager.RandomForPowerUp();
            gameManager.Score();
        }
        else if (swipeControl.hasSwipedUp == true && enemyChecker.enemy != EnemyDirection.Up && isSwiped == false)
        {
            isSwiped = true;
            Invoke(nameof(NewFunction_Up), 0.0005f);
        }

        if (swipeControl.hasSwipedDown == true && enemyChecker.enemy == EnemyDirection.Down && Enemies[0] != null)
        {
            GameObject ToDestroy = Enemies[Enemies.Count - 1];
            Destroy(ToDestroy);
            Enemies.RemoveAt(Enemies.Count - 1);

            swipeControl.hasSwipedDown = false;
            gameManager.AddDashMeter();
            gameManager.RandomForPowerUp();
            gameManager.Score();
        }
        else if (swipeControl.hasSwipedDown == true && enemyChecker.enemy != EnemyDirection.Down && isSwiped == false)
        {
            isSwiped = true;
            Invoke(nameof(NewFunction_Down), 0.0005f);
        }

        if (Enemies[0] == null)
        {
            Enemies.RemoveAll(Enemies => !Enemies);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<EnemyScript>() != null)
        {
            Enemies.Add(collision.gameObject);
        }

    }

    public void NewFunction_Right()
    {
        gameManager.DecreaseHealth(1f);
        isSwiped = false;
        swipeControl.hasSwipedRight = false;
    }

    public void NewFunction_left()
    {
        gameManager.DecreaseHealth(1f);
        isSwiped = false;
        swipeControl.hasSwipedLeft = false;
    }

    public void NewFunction_Up()
    {
        gameManager.DecreaseHealth(1f);
        isSwiped = false;
        swipeControl.hasSwipedUp = false;
    }

    public void NewFunction_Down()
    {
        gameManager.DecreaseHealth(1f);
        isSwiped = false;
        swipeControl.hasSwipedDown = false;
    }

}
