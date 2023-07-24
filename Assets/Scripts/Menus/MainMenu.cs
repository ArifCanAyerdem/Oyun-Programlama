using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuObj;
    public GameObject settingsMenuObj;

    public void playButton () // oyunu menüden başlangıç sahnemize atan kodumuz
    {
        SceneManager.LoadScene("Sero_Sahne");
    }

    public void settingsButton()
    {
        mainMenuObj.SetActive(false);
        settingsMenuObj.SetActive(true);
    }

    public void quitButton()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void lowQualityButton()
    {
        Debug.Log("Dusuk Kalite Secildi");
        QualitySettings.SetQualityLevel(0, true);
    }
    public void medQualityButton()
    {
        Debug.Log("Orta Kalite Secildi");
        QualitySettings.SetQualityLevel(1, true);
    }
    public void highQualityButton()
    {
        Debug.Log("Yuksek Kalite Secildi");
        QualitySettings.SetQualityLevel(2, true);
    }

    public void returnButton()
    {
        mainMenuObj.SetActive(true);
        settingsMenuObj.SetActive(false);
    }
}