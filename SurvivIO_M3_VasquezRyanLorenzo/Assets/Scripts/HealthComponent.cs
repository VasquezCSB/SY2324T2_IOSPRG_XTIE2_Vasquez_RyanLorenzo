using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum enemyType
{
    player,
    enemy
}
public class HealthComponent : MonoBehaviour
{
    public Image healthBar;
    public float maxHealth = 100f;
    public float currentHealth;
    public enemyType enemyTypeVar;
    public bool test;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
        }
        healthBar.fillAmount = currentHealth / maxHealth;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if(enemyTypeVar == enemyType.enemy)
        {
            Destroy(this.gameObject);
        } else
        {
            test = true;
            //this.gameObject.SetActive(false);
        }
    }
}
