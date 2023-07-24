using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Enventory : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public int destroyedObjectCount;
    public TMP_Text collectedAmount;
    public GameObject enventoryUI;

    void Update() // envanter menümzün açılmasını sağlayan kodumuz
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
        collectedAmount.text = $"Gas Count: {(destroyedObjectCount).ToString()}"; // envanterde toplanan nesnenin kontrölü sağlayıp ekrana sayısını yazdıran kodmumuz
    }
    
    public void Resume ()
    {
        enventoryUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameIsPaused = false;
    }
    public void Pause ()
    {
        enventoryUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameIsPaused = true;
    }
}
