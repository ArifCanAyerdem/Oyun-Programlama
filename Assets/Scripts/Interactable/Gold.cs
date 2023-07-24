using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()                                        //Bu script parcaciklari etkilesime gecilen nesnelere atanir. Mesela oyuna benzin objesi eklemek istersek
    {                                                    //bu scripti cogaltip, dosya ve class adini yeni objemizin adi yapariz. Ve etkilesime girilince ne olmasini
                                                         //istiyorsak Interact fonkisyonuna yazariz.
    }
    protected override void Interact(){
        Debug.Log(gameObject.name+" ile etkileşime geçildi!");         
    }                                                                      
}
