using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare_Obj : MonoBehaviour
{

    public float speed;
    public AudioSource soundSource;
    public AudioClip scarySound;

    public GameObject ScaryWall;

    bool isPlayed;
    bool movee;

    void Start()
    {
        isPlayed = false;
        soundSource.clip = scarySound;
    }

    private void Update()
    {
        if (movee)
        {
            transform.Translate(-transform.forward * Time.deltaTime * speed);
        }
    }

    //Duvara girince.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(scare()); // unityde kullanılan ve zaman tabanlı işlemleri yönetmek için kullanılan yapı
        }
        if (other.gameObject.tag == "Jumpscarewall")
        {
            movee = true;
        }
    }

    IEnumerator scare() // Zamanlayıcı fonksiyonumuz ne zaman çalışacağını belirtir.
    {
        if (!isPlayed)
        {
            soundSource.Play();
            ScaryWall.SetActive(true);
            isPlayed = true;
        }
        yield return new WaitForSeconds(0.5f);
        ScaryWall.SetActive(false);
    }
}
