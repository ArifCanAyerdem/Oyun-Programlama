using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : Interactable
{
    public GameObject campFireFlames;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact(){
        Debug.Log(gameObject.name+" ile etkileşime geçildi!");
        if (campFireFlames.activeInHierarchy)
            {
                campFireFlames.SetActive(false);
            }
            else{
                campFireFlames.SetActive(true);
            }
    }

    /* private void OnTriggerEnter(Collider other) {
        Interact();
    } */
}
