using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AtesEtme : MonoBehaviour
{
    public float reloadcooldown;
    public float AmmoInGun;
    public float AmmoInPocket;
    public float AmmoMax;
    float AddableAmmo;
    float reloadtimer;

    public GameObject impactEffect;
    public GameObject BloodyimpactEffect;
    RaycastHit hit;
    RaycastHit Takehit;
    public GameObject MermiCikisNoktasi;
    public GameObject MainRayPoint;
    public bool AtesEdebilir;
    float GunTimer;
    public float TaramaHizi;
    public float damage;
    public ParticleSystem MuzzleFlash;
    AudioSource SesKaynak;
    public AudioClip AtesSesi;
    public float Menzil;
    public float takerange;
    public CharacterController Karakter;
    public AudioClip ReloadSound;
    public GameObject crosshair;
    public LayerMask takeitem;
    public TextMeshProUGUI AmmoCounter;
    public TextMeshProUGUI PocketAmmoCounter;

    Animator GunAnimset;

    // Start is called before the first frame update
    //Bu kod bloğu, Unity oyun motoru kullanılarak bir silahın ateş etme ve yeniden yükleme işlevselliğini sağlayan C# scriptidir.
    //Kod, silahın şarjör ve cebindeki mermi sayısını takip eder ve ateş etme, yeniden yükleme ve mermi toplama gibi işlemleri gerçekleştirir.
    //Kod, kullanıcının fare tıklaması ve R tuşuna basması gibi girdileri alarak silahın davranışını değiştirir.
    //Ayrıca, kod mermi isabet ettiğinde çeşitli etkiler ve hasar hesaplamaları uygular.
    void Start()
    {
        SesKaynak = GetComponent<AudioSource>();
        GunAnimset = GetComponent<Animator>();
        AmmoCounter = GameObject.FindWithTag("AmmoCounter").transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        PocketAmmoCounter = GameObject.FindWithTag("AmmoCounter").transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(MermiCikisNoktasi.transform.position, MermiCikisNoktasi.transform.forward, Color.green);
        if (Physics.Raycast(MermiCikisNoktasi.transform.position, MermiCikisNoktasi.transform.forward, out Takehit, Menzil, takeitem))//Işın Gönderimi
        {
            if (Input.GetKeyDown(KeyCode.F))//F tuşu ile alma ve yok etme komutu
            {
                Debug.Log("Ammo picked up!");
                AmmoInPocket = AmmoInPocket + 30;
                Destroy(Takehit.collider.gameObject);

            }
        }
        

        AmmoCounter.text = AmmoInGun.ToString();
        PocketAmmoCounter.text = AmmoInPocket.ToString();
        AddableAmmo = AmmoMax - AmmoInGun;

        if (AddableAmmo > AmmoInPocket)
        {
            AddableAmmo = AmmoInPocket;
        }

        if (Input.GetKeyDown(KeyCode.R) && AddableAmmo > 0 && AmmoInPocket > 0)
        {
            if (Time.time > reloadtimer)
            {
                StartCoroutine(Reload());
                reloadtimer = Time.time + reloadcooldown;
            }
        }
        else if (Input.GetKey(KeyCode.Mouse0) && AtesEdebilir == true && Time.time > GunTimer && AmmoInGun > 0 && Time.time > reloadtimer + 1)
        {
            Fire();
            GunTimer = Time.time + TaramaHizi;
        }
    }

    void Fire()
    {  // ateş ederken amma azalması effect çalışması ,ses çalışması ve taga göre çalışması sağlandı.
        AmmoInGun--;
        CameraShake.Instance.ShakeCamera();
        if (Physics.Raycast(MermiCikisNoktasi.transform.position, MermiCikisNoktasi.transform.forward, out hit, Menzil))
        {
            MuzzleFlash.Play();//Silahın ucundan çıkan flaş
            SesKaynak.clip = AtesSesi;
            SesKaynak.Play();
            GunAnimset.Play("fire", -1, 0f);


            if (hit.collider.tag == "Untagged")
            {
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }

            if (hit.collider.tag == "Enemy")
            {
                Instantiate(BloodyimpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                hit.collider.gameObject.transform.root.GetComponent<Enemy>().health -= damage;
            }
        }
    }

    IEnumerator Reload()
    {
        GunAnimset.SetBool("isReloading", true);

        SesKaynak.clip = ReloadSound;
        SesKaynak.Play();

        yield return new WaitForSeconds(0.3f);
        GunAnimset.SetBool("isReloading", false);

        yield return new WaitForSeconds(1.4f);
        AmmoInGun = Mathf.Min(AmmoInGun + AddableAmmo, AmmoMax);
        AmmoInPocket = Mathf.Max(AmmoInPocket - AddableAmmo, 0f);

        // Reload s�ras�nda ate� edilemez
        AtesEdebilir = false;

        // Reload tamamland�ktan sonra ate� edilebilir hale getir
        yield return new WaitForSeconds(reloadcooldown);
        AtesEdebilir = true;
    }
}
