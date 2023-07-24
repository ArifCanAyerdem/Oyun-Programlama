using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bu kod, bir kamera sarsýntý efekti oluþturmak için kullanýlan bir CameraShake sýnýfý içerir.
//Sýnýf, kameranýn orijinal konumunu ve çeþitli sarsýntý parametrelerini tutar.
//Kamera sarsýntýsý için gerekli özelliklerin belirtilmesi ardýndan ShakeCamera() yöntemi çaðrýlabilir.
//Bu yöntem, canShake deðiþkenini true yaparak kamera sarsýntýsýný baþlatýr. StartCameraShakeEffect() yöntemi,
//canShake deðiþkeni true olduðunda kamera konumunu deðiþtirerek sarsýntý efektini oluþturur.
//Sarsýntý süresi dolana kadar bu efekt devam eder ve süre bittiðinde kamera orijinal konumuna geri döner ve canShake deðiþkeni false yapýlýr.

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
