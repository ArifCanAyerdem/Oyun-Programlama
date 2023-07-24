using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granede : MonoBehaviour
{
    Rigidbody rb;
    public GameObject cameraObject;
    public float speed;
    public ParticleSystem explosion;
    public float explosionForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(ThrowGranade());
        }
    }

    IEnumerator ThrowGranade()
    {
        transform.parent = null;
        rb.useGravity = true;
        rb.AddForce(cameraObject.transform.forward * speed * Time.deltaTime, ForceMode.VelocityChange);//Kameranın ileri yönde olan vektörüne,
        yield return new WaitForSeconds(3f);                                                           //belirli bir hızda ve deltaTime ile çarpılarak bir kuvvet uygulanır. 
        ParticleSystem explosive = Instantiate(explosion, transform.position, transform.rotation);     //Bombanın fırlatılmasını sağlar.
        explosive.Play();
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosive.main.startLifetime.constant * explosionForce);
        foreach (Collider col in colliders)
        {
            Rigidbody rb = col.attachedRigidbody;
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosive.main.startLifetime.constant, 1f, ForceMode.Impulse);
            }
        }
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
        Destroy(explosive.gameObject);
    }
}