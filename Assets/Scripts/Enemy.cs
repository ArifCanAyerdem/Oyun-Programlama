using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public Player_Health playerHealthSc;
    Animator ZombieAnim;

    public Transform hedef;
    NavMeshAgent Agent;
    public float time;
    public float timeTresh=3f;

    public float mesafe;

    public float health;
    Collider bCollider;
    Collider cCollider;
    public float attackTimer = 3f;
    void Start()
    {
        bCollider = GetComponent<BoxCollider>();
        cCollider = GetComponent<CapsuleCollider>();
        ZombieAnim = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        ZombieAnim.SetFloat("hiz", Agent.velocity.magnitude);

        ZombieAnim.SetFloat("can", health);
        mesafe = Vector3.Distance(transform.position, hedef.position);
        //Bu script, Enemy adl� bir d��man karakteri i�in yaz�lm��t�r.
        //D��man, hedef adl� bir Transform de�i�kenine hareket eder ve NavMeshAgent bile�eni kullanarak hareket eder.
        //D��man�n can� health de�i�keni taraf�ndan tutulur ve d��man �l�rse Destroy fonksiyonu kullan�larak yok edilir.
        //D��man karakteri oyuncu(Player) karakteriyle temas halinde olursa,
        //OnTriggerEnter fonksiyonu tetiklenir ve oyuncunun sa�l���(playerHealthSc.health) 25 azalt�l�r.
        //Daha sonra, d��man�n temas halinde oldu�u s�reyi(time) takip etmek i�in OnTriggerStay fonksiyonu kullan�l�r.
        //Belirli bir zaman aral���(timeTresh) ge�ti�inde, d��man tekrar oyuncuyu hasar verir.

        if (health > 0)
        {
            if (mesafe <= 10)
            {
                Agent.enabled = true;
                Agent.SetDestination(hedef.position);
            }
            else
            {
                Agent.enabled = false;
            }
        }
        else
        {
            bCollider.enabled = false;
            cCollider.enabled = false;
            Destroy(gameObject, 4f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            playerHealthSc.health -= 25;
            time = 0f;
        }
    }
    
   private void OnTriggerStay(Collider other)
    {
        time += Time.deltaTime;
        if (other.CompareTag("Player"))
        {
            if(time<timeTresh) {time+=Time.deltaTime;}

            else 
            {
            playerHealthSc.health -= 25;
            time =0f;
            }
        }
    }

    
    
}
