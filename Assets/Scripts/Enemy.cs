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
        //Bu script, Enemy adlý bir düþman karakteri için yazýlmýþtýr.
        //Düþman, hedef adlý bir Transform deðiþkenine hareket eder ve NavMeshAgent bileþeni kullanarak hareket eder.
        //Düþmanýn caný health deðiþkeni tarafýndan tutulur ve düþman ölürse Destroy fonksiyonu kullanýlarak yok edilir.
        //Düþman karakteri oyuncu(Player) karakteriyle temas halinde olursa,
        //OnTriggerEnter fonksiyonu tetiklenir ve oyuncunun saðlýðý(playerHealthSc.health) 25 azaltýlýr.
        //Daha sonra, düþmanýn temas halinde olduðu süreyi(time) takip etmek için OnTriggerStay fonksiyonu kullanýlýr.
        //Belirli bir zaman aralýðý(timeTresh) geçtiðinde, düþman tekrar oyuncuyu hasar verir.

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
