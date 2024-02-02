using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public enum PlayerType
{
    Default,
    Tank,
    Speed
}

public class SkinManager : MonoBehaviour
{
    public static SkinManager instance;

    public GameObject[] classTexts;
    private int classHP;
    private int classDashValue;
    private SpriteRenderer classSpriteRenderer;
    private int classIndex = 0;

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void PlayGame()
    {
        if (classIndex == 0) //Default
        {
            SetClassHP(3);
            SetDashValue(5);

        }else if(classIndex == 1) //Tank
        {
            SetClassHP(5);
            SetDashValue(5);
        }
        else if(classIndex == 2) //Speed
        {
            SetClassHP(3);
            SetDashValue(10);
        }

        SceneManager.LoadScene("SampleScene");
    }

    public void Next() {
        classTexts[classIndex].SetActive(false);

        classIndex = (classIndex + 1) % classTexts.Length;

        SwitchClass();
    }

    public void SwitchClass()
    {
        classTexts[classIndex].SetActive(true);
    }

    public void SetClassHP(int hp)
    {
        classHP = hp;
    }

    public int GetClassHP()
    {
        return classHP;
    }

    public void SetDashValue(int dashValue)
    {
        classDashValue = dashValue;
    }

    public int GetDashValue()
    {
        return classDashValue;
    }

    public void SetClassIndex(int cIndex)
    {
        classIndex = cIndex;
    }

    public int GetClassIndex()
    {
        return classIndex;
    }
}
