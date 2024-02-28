using UnityEngine;
using System.Collections;

public class RotateGun : MonoBehaviour
{
    public Joystick rightJoystick;
    void Update()
    {
        Vector3 moveVector = (Vector3.up * rightJoystick.Horizontal + Vector3.left * rightJoystick.Vertical);
        if (rightJoystick.Horizontal != 0 || rightJoystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
        }


    }
}
