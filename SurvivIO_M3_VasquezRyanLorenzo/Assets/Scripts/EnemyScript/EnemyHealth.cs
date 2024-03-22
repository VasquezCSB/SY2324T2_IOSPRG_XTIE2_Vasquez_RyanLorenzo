using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    //public static EnemyHealth instance;
    public Image enemyHealth;
    [SerializeField] private Slider healthSlider;

    //private void Awake()
    //{
    //    instance = this;
    //}
    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyHealthBar(float currentHealth, float maxHealth)
    {
        enemyHealth.fillAmount = currentHealth/maxHealth;
    }
}
