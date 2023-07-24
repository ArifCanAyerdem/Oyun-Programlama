using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    [SerializeField] public bool canFire = true;
    public GameObject Weapon_Fists;  //Hiyerarşi 1. Çocuk - index 0
    public GameObject WSlot1;  //Hiyerarşi 2. Çocuk - index 1
    public GameObject WSlot2;  //Hiyerarşi 3. Çocuk - index 2
    void Start()
    {
        WSlot1 = transform.GetChild(0).gameObject;   
        if (WSlot2 == null)
        {
            WSlot2 = Weapon_Fists;
        }
        WSlot2.SetActive(false);
    }

    void Update()
    {
        WSlot2 = transform.GetChild(1).gameObject;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Invoke("Switch1", 0f); //1 saniye sonra bu fonksiyonu çalıştır. meali : silahı ortadan kaldırma animasyonu için 1 saniyen var
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Invoke("Switch2", 0f); //ANIMASYON ISINI COZUNCE ZAMAN BELIRLE
        }
    }

    void Switch1()
    {
        WSlot1.SetActive(true);
        WSlot2.SetActive(false);
    }

    void Switch2()
    {
        WSlot1.SetActive(false);
        WSlot2.SetActive(true);
    }
}
