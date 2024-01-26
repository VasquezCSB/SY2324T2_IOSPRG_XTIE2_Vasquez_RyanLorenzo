using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyDirection
{
    Up,
    Down, 
    Left, 
    Right
}

public class EnemyScript : MonoBehaviour
{
    [Header("Enemy Movement")]
    public float moveSpeed = 5;
    public float death = -0.05f;
    public EnemyDirection thisEnemyDirection;

    int randomizer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = transform.position + (Vector3.down * moveSpeed) * Time.deltaTime;

        if (transform.position.y < death)
        {
            Destroy(gameObject);

        }
    }
}
