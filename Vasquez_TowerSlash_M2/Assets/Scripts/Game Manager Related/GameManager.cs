using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //For Dash Gauge
    int dashValue;
    public TMP_Text dashMeter;
    public Button dashButton;
    public GameObject invincibility;

    //For PowerUp
    public float playerHP = 1;
    public TMP_Text playerHPText;
    int powerUpRandom;

    //Game Over Screen
    public TMP_Text gameOverText;
    public Button gameOverButton;
    public Spawner spawner; 


    // Start is called before the first frame update
    void Start()
    {
        playerHPText.text = "HP: " + playerHP;
        dashMeter.text = "DP: " + dashValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHP <= 0)
        {
            OnDefeat();
        }
    }

    public void SpeedUp()
    {
        Time.timeScale = 3.0f;
    }

    public void BackToNormal()
    {
        Time.timeScale = 1.0f;

    }

    //For PowerUp
    public void RandomForPowerUp()
    {
        powerUpRandom = Random.Range(0, 100);

        if (powerUpRandom == 3)
        {
            playerHP += 1;
            playerHPText.text = "HP: " + playerHP;
        }
    }

    //For health
    public void DecreaseHealth(float damage)
    {

        playerHP -= damage;
        playerHPText.text = "HP: " + playerHP;

    }

    //For Defeat
    public void OnDefeat()
    {
        gameOverText.gameObject.SetActive(true);
        gameOverButton.gameObject.SetActive(true);
        spawner.gameObject.SetActive(false);

    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    //For DashGauge
    public void AddDashMeter()
    {
        dashValue += 5;
        dashMeter.text = "DP: " + dashValue;

        if (dashValue == 100)
        {
            dashButton.gameObject.SetActive(true);
        }
    }

    public void OnDash()
    {
        dashMeter.text = "DP: " + dashValue;
        invincibility.gameObject.SetActive(true);
        StartCoroutine(BoostCount());
    }

    IEnumerator BoostCount()
    {
        dashValue = 0;
        dashButton.gameObject.SetActive(false);

        Time.timeScale = 2.0f;

        yield return new WaitForSeconds(7);

        invincibility.gameObject.SetActive(false);

        Time.timeScale = 1.0f;

    }
}
