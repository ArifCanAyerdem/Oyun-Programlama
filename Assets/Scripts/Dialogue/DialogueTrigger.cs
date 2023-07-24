using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private bool playerInRange ;
    [Header("Ink Json")]
    [SerializeField] private TextAsset inkJSON;
   
    private void Awake() {
        playerInRange = false;
        
    }

    private void Update() {
        if(playerInRange && !DialogueManager.GetInstance().dialagueIsPlaying){
            if (Input.GetKeyDown(KeyCode.F))
             {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
             }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player"){
    
              playerInRange=true;
        }
        
    }
    private void OnTriggerExit(Collider other) 
    {
    
         if(other.gameObject.tag == "Player"){
              
              playerInRange=false;
        }
    }
}
