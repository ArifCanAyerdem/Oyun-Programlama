using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCan : Interactable
{
    public Enventory inventorySc;

    private void Start() {
        inventorySc = GameObject.FindGameObjectWithTag("Player_UI").GetComponent<Enventory>();
    }
    
    protected override void Interact(){ //envanter menümüz için oluşturmuş olduğumuz bir objemizin sayac vazifesi gören kodumuz
        inventorySc.destroyedObjectCount++;
        Destroy(this.gameObject,0.1f);
    }
}
