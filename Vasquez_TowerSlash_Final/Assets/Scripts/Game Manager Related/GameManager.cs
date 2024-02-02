using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Dash Gauge")]
    int dashValue;
    int addedDashValue;
    public TMP_Text dashMeter;
    public Button dashButton;
    public GameObject invincibility;

    //For PowerUp
    [Header("PowerUp")]
    private float playerHP;
    public TMP_Text playerHPText;
    int powerUpRandom;

    //Game Over Screen
    [Header("Game Over")]
    public TMP_Text gameOverText;
    public TMP_Text scoreUI;
    public Button gameOverButton;
    public Spawner spawner;

    //Score
    [Header("Score")]
    public TMP_Text scoreText;
    public int score;

    [Header("Player Skin")]
    public GameObject selectedSkin;
    public GameObject player;

    private Sprite playerSprite;

    public GameManager instance;
    public SwipeControls swipeControl;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        swipeControl = SwipeControls.instance.gameObject.GetComponent<SwipeControls>();

        playerHP = SkinManager.instance.GetClassHP();
        addedDashValue = SkinManager.instance.GetDashValue();

        if(SkinManager.instance.GetClassIndex() == 1)
        {
            player.gameObject.GetComponent<SpriteRenderer>().color = Color.green;

        } else if (SkinManager.instance.GetClassIndex() == 2)
        {
            player.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }

        playerHPText.text = "HP: " + playerHP;
        dashMeter.text = "DP: " + dashValue;
        scoreText.text = "Score: " + score;
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

    public void Score()
    {
        score += 1;
        scoreText.text = "Score: " + score;
        scoreUI.text = "Score: " + score;
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
        scoreUI.gameObject.SetActive(true);
        spawner.gameObject.SetActive(false);

    }

    public void Restart()
    {
        SceneManager.LoadScene("ChooseSkin");
    }

    //For DashGauge
    public void AddDashMeter()
    {
        dashValue += addedDashValue;
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
        swipeControl.invincibleON = true;
        dashValue = 0;
        dashButton.gameObject.SetActive(false);

        Time.timeScale = 2.0f;

        yield return new WaitForSeconds(7);

        invincibility.gameObject.SetActive(false);
        swipeControl.invincibleON = false;

        Time.timeScale = 1.0f;

    }
}
