using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Crawler : MonoBehaviour
{
    public float speed;
    public bool move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (move)// Crawlerın hareket etme fonksiyonu
        transform.Translate(-transform.forward * Time.deltaTime * speed);
    }
}
