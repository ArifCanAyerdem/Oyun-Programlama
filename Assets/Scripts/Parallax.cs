using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject _cam;
    [SerializeField] private float _speed;
    void Update()
    {
        transform.Translate(1 * _speed * Time.deltaTime, 0.0f, 0.0f); //Translate fonksiyonu, objenin konumunu _speed
                                                                      //deðiþkeniyle çarparak belirtilen hýzda hareket ettirir.

        if (_cam.transform.position.x >= transform.position.x + 18f) //Bu kod bloðu, objenin kameranýn arkasýnda kalmamasýný saðlar.
                                                                     //Eðer obje, _cam GameObject'inin X pozisyonundan 18f birim uzakta kalýyorsa,
                                                                     //objenin pozisyonunu kameranýn X pozisyonu + 18f birim olacak þekilde günceller.
                                                                     //Bu iþlem, objenin sonsuz gibi görünmesini saðlar.
        {
            transform.position = new Vector2(
                _cam.transform.position.x + 18f,
                transform.position.y
            );
        }
    }
}
