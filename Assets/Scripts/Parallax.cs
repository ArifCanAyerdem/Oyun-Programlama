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
                                                                      //de�i�keniyle �arparak belirtilen h�zda hareket ettirir.

        if (_cam.transform.position.x >= transform.position.x + 18f) //Bu kod blo�u, objenin kameran�n arkas�nda kalmamas�n� sa�lar.
                                                                     //E�er obje, _cam GameObject'inin X pozisyonundan 18f birim uzakta kal�yorsa,
                                                                     //objenin pozisyonunu kameran�n X pozisyonu + 18f birim olacak �ekilde g�nceller.
                                                                     //Bu i�lem, objenin sonsuz gibi g�r�nmesini sa�lar.
        {
            transform.position = new Vector2(
                _cam.transform.position.x + 18f,
                transform.position.y
            );
        }
    }
}
