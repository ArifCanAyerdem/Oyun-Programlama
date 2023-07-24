using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Inventory : Interactable
{
    public Enventory inventorySc;
    
    protected override void Interact(){ //envanter menümüz için oluşturmuş olduğumuz bir objemizin sayac vazifesi gören kodumuz
        inventorySc.destroyedObjectCount++;
        Destroy(this.gameObject,0.1f);
    }
}
