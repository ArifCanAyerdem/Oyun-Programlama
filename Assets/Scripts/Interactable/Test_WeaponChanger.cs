using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_WeaponChanger : Interactable
{
    public GameObject weaponManager;
    public GameObject weapon_M4;
    private GameObject instantiatedobject;

    protected override void Interact()// İki silah arasında geçiş yaparken kapama açma işlemi gerçekleşiyor
    {
        instantiatedobject = Instantiate(weapon_M4);
        instantiatedobject.transform.SetParent(weaponManager.transform);
        Destroy(weaponManager.transform.GetChild(1).gameObject);
        weaponManager.transform.GetChild(0).gameObject.SetActive(false);
        weaponManager.transform.GetChild(0).gameObject.SetActive(true);
        Destroy(gameObject);
    }
}

