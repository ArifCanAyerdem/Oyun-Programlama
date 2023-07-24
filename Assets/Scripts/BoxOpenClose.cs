using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOpenClose : MonoBehaviour
{
    Animator animator;
    public float delay = 3f;
    public AudioClip sound;
    public GameObject prefab;
    public GameObject player; //Oyuncu objesi
    public float minDistance = 1.5f; //Sesin en yak�n duyulabilece�i mesafe

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("isClose", true);
            SpawnPrefab();
            Invoke("DestroyBox", delay - 1f);
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            animator.SetBool("isClose", false);
        }
    }

    void DestroyBox()
    {
        Destroy(gameObject);
    }
    void SpawnPrefab()
    {
        Vector3 spawnPosition = transform.position + new Vector3(1f, 1f, 0f);
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }

    
}

