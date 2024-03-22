using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    //public Image healthBar;
    public float healthAmount = 100;
    public static HealthManager instance;
    public InterfaceManager interfaceManager;
    public GameObject player;

    private void Awake()
    {
        instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            Destroy(player);
        }
    }

    public void TakeDamage(int damage)
    {
        healthAmount -= damage;
        interfaceManager.healthBar.fillAmount = healthAmount / 100f;
    }
}
