using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{
     public Player_Health playerHealthSc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          
   

    }
    private void OnTriggerEnter(Collider other)
     {
     if (other.CompareTag("Player") && playerHealthSc.health<=70){
            Debug.Log("sa");
            playerHealthSc.health += 30 ;
            Destroy(this.gameObject);

        }
    else if(other.CompareTag("Player") && playerHealthSc.health>=70 && playerHealthSc.health<100){
        playerHealthSc.health = playerHealthSc.maxHealth;
        Destroy(this.gameObject);
    }
    else {
        Debug.Log("Full Can");
    }
   }
   
}
