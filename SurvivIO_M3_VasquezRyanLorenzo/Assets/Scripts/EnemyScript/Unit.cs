using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] protected float curHealth;
    [SerializeField] protected float maxHealth = 100;

    [SerializeField] protected float minspeed;
    [SerializeField] protected float maxSpeed;
}
