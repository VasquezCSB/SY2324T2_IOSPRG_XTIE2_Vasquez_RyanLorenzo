using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : Unit
{
    [SerializeField] private Rigidbody2D rb; 
    public Joystick leftJoyStick;
    public Joystick rightJoyStick;
    public GameObject bullet;


    [SerializeField] private HealthComponent health;
    [SerializeField] private InterfaceManager interfaceManager;

    Vector2 move;
    [SerializeField] private float _moveSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        move.x = leftJoyStick.Horizontal;
        move.y = leftJoyStick.Vertical;

        if (health.test == true)
        {
            interfaceManager.GameOver();
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * _moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.GetComponent<BulletMovement>() != null)
        {
            Destroy(collision.gameObject);
            this.GetComponent<HealthComponent>().TakeDamage(bullet.GetComponent<BulletMovement>().damage);
                
        }
    }

    public void GameOver()
    {
        Debug.Log("Alfred");
    }
}
