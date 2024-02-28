using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb; 
    public Joystick leftJoyStick;
    public Joystick rightJoyStick;

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
}
