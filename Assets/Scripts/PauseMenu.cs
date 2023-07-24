using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuObj;
    public GameObject settingsMenuObj;
    public GameObject scenesMenuObj;
    public static bool GameIsPaused = false;
    //public AtesEtme atesetmesc;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //Esc ile oyunu durdurduğumuz kod bloğumuz
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }
    
    public void Resume () // karakterin baktıgı yerde harekliği durduran ve devam ettiren kod bloğu
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
       // atesetmesc.AtesEdebilir = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameIsPaused = false;
    }
    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
       // atesetmesc.AtesEdebilir = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameIsPaused = true;
    }

    public void LoadMainMenu() //ana menüye geçişi sağlayan kodumuz
    {
        Debug.Log("Loading Menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Yilmaz_Sahne");
    }

    public void LoadSettingsMenu() //ayarlar menümüzü aktif eden kodumuz
    {
        pauseMenuObj.SetActive(false);
        settingsMenuObj.SetActive(true);
        scenesMenuObj.SetActive(false);
        Debug.Log("Loading Menu..");
    }
    public void scenesMenu() // sahneler arası geçişi sağlayan kodumuz
    {
        pauseMenuObj.SetActive(false);
        settingsMenuObj.SetActive(false);
        scenesMenuObj.SetActive(true);
        Debug.Log("Loading Menu..");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void lowQualityButton() // çözünürlüğü değiştirmeyi sağladığımız kodumuz
    {
        Debug.Log("Dusuk Kalite Secildi");
        QualitySettings.SetQualityLevel(0, true);
    }
    public void medQualityButton() // çözünürlüğü değiştirmeyi sağladığımız kodumuz
    {
        Debug.Log("Orta Kalite Secildi");
        QualitySettings.SetQualityLevel(1, true);
    }
    public void highQualityButton() // çözünürlüğü değiştirmeyi sağladığımız kodumuz
    {
        Debug.Log("Yuksek Kalite Secildi");
        QualitySettings.SetQualityLevel(2, true);
    }

    public void returnButton()
    {
        pauseMenuObj.SetActive(true);
        settingsMenuObj.SetActive(false);
        scenesMenuObj.SetActive(false);
    }

    public void loadForest()
    {
        Debug.Log("Loading Menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Arif_Sahne");
    }
    public void loadTestArea()
    {
        Debug.Log("Loading Menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Mustafa_Sahne");
    }
    public void loadCamp()
    {
        Debug.Log("Loading Menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Sero_Sahne");
    }
}