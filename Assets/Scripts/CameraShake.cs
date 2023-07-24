using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bu kod, bir kamera sars�nt� efekti olu�turmak i�in kullan�lan bir CameraShake s�n�f� i�erir.
//S�n�f, kameran�n orijinal konumunu ve �e�itli sars�nt� parametrelerini tutar.
//Kamera sars�nt�s� i�in gerekli �zelliklerin belirtilmesi ard�ndan ShakeCamera() y�ntemi �a�r�labilir.
//Bu y�ntem, canShake de�i�kenini true yaparak kamera sars�nt�s�n� ba�lat�r. StartCameraShakeEffect() y�ntemi,
//canShake de�i�keni true oldu�unda kamera konumunu de�i�tirerek sars�nt� efektini olu�turur.
//Sars�nt� s�resi dolana kadar bu efekt devam eder ve s�re bitti�inde kamera orijinal konumuna geri d�ner ve canShake de�i�keni false yap�l�r.

public class CameraShake : MonoBehaviour
{
    // Camera Information
    public Transform cameraTransform;
    private Vector3 orignalCameraPos;

    // Shake Parameters
    public float shakeDuration = 2f;
    public float shakeAmount = 0.7f;

    private bool canShake = false;
    private float _shakeTimer;

    public static CameraShake Instance;

    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        orignalCameraPos = cameraTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (canShake)
        {
            StartCameraShakeEffect();
        }
    }

    public void ShakeCamera()
    {
        canShake = true;
        _shakeTimer = shakeDuration;
    }

    public void StartCameraShakeEffect()
    {
        if (_shakeTimer > 0)
        {
            cameraTransform.localPosition = orignalCameraPos + Random.insideUnitSphere * shakeAmount;
            _shakeTimer -= Time.deltaTime;
        }
        else
        {
            _shakeTimer = 0f;
            cameraTransform.localPosition = orignalCameraPos;
            canShake = false;
        }
    }

}
