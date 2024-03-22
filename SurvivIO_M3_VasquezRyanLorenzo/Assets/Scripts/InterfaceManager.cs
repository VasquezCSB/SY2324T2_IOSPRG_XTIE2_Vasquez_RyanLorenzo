using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    public Image healthBar;

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

}
