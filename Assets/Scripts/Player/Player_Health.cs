using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    public int health = 100;
    public int maxHealth=100;
    public TMP_Text health_Text;
    int current_index;

    void Update()
    {
        health_Text.text = $"+ {health}";
        if(health <= 0){
            health = 0;
            health_Text.text = "DEAD!";
            SceneManager.LoadScene("Mustafa_Sahne");
        }
    }
}
