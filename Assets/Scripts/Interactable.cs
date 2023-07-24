using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool useEvents;
    [SerializeField] public string promptMessage;
    
    public virtual string Onlook()
    {
        return promptMessage;
    }
    public void BaseInteract(){
        if(useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();     //Etkilesime gecilen nesne, ana kod
        Interact();
    }
    protected virtual void Interact(){

    }
}
