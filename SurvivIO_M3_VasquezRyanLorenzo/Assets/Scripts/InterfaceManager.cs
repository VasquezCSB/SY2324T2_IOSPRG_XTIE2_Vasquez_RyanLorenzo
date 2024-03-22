using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    public Image healthBar;
    public Image background;
    public TextMeshProUGUI gameOverText;
    public Button restart;
    public Button exit;
    public GameObject spawner;

    [SerializeField] private PlayerMovement playerMovement;
    [Header("Clip Count Text Vars")]
    public TextMeshProUGUI clipCount;

    [Header("Reload Clip Text Vars")]
    public TextMeshProUGUI reloadClip_Pistol;
    public TextMeshProUGUI reloadClip_Shotgun;
    public TextMeshProUGUI reloadClip_Automatic;
    
    public void UpdatePistolAmmoUI(int value)
    {
        reloadClip_Pistol.text = value.ToString();
    }

    public void UpdateShotgunAmmoUI(int value)
    {
        reloadClip_Shotgun.text = value.ToString();
    }

    public void UpdateAutomaticAmmoUI(int value)
    {
        reloadClip_Automatic.text = value.ToString();
    }
    public void UpdateClipCount(int value)
    {
        clipCount.text = value.ToString();
    }

    public void GameOver()
    {
        background.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        exit.gameObject.SetActive(true);
        Destroy(spawner);
    }
    public void RestartGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        // Quit the application (works in standalone builds)
        Application.Quit();
    }
}
