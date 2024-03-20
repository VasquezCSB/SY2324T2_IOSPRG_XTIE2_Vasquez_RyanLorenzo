using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Unit
{
    [SerializeField] private Rigidbody2D rb; 
    public Joystick leftJoyStick;
    public Joystick rightJoyStick;
    public BulletMovement bullet;

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
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * _moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("HasBullet");

        if (collision.gameObject.GetComponent<BulletMovement>() != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
