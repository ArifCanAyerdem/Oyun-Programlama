using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelection : MonoBehaviour
{
    int current_index;
    int map_index;
    public GameObject mapPanel;
    public Enventory inventorySc;

    private void Start()
    {
        current_index = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("current scene id: " + current_index);
    }
    public void map_forest() // oyunu menüden başlangıç sahnemize atan kodumuz
    {
        if(inventorySc.destroyedObjectCount >= 1){
            map_index = 3;
            if (map_index == current_index)
            {
            Debug.Log("You are already in this scene.");
            }
            else
            {
                SceneManager.LoadScene("Arif_Sahne");
                mapPanel.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        else{
            Debug.Log("yakit sayisi yeterli degil ");
        }
    }
    public void map_camp() // oyunu menüden başlangıç sahnemize atan kodumuz
    {
        if(inventorySc.destroyedObjectCount >= 2){
            map_index = 1;
            if (map_index == current_index)
            {
            Debug.Log("You are already in this scene.");
            }
            else
            {
            SceneManager.LoadScene("Sero_Sahne");
            mapPanel.SetActive(false);
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            }
        }
        else{
            Debug.Log("yakit sayisi yeterli degil ");
        }
    }
    public void map_testarea() // oyunu menüden başlangıç sahnemize atan kodumuz
    {
        if(inventorySc.destroyedObjectCount >= 3){
            map_index = 2;
            if (map_index == current_index)
            {
            Debug.Log("You are already in this scene.");
            }
            else
            {
            SceneManager.LoadScene("Mustafa_Sahne");
            mapPanel.SetActive(false);
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            }
        }
        else{
            Debug.Log("yakit sayisi yeterli degil ");
        }
    }
    public void buttonClose() // oyunu menüden başlangıç sahnemize atan kodumuz
    {
        mapPanel.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
