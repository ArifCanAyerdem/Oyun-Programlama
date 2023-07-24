using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;
    public float xSensitivity = 30f;
    public float ySensitivity = 30f;
    public float defSensX;
    public float defSensY;
    public GameObject flashLightObject;

    private void Start()
    {
        defSensX = xSensitivity;            //Diyaloğa girilince hassasiyeti sıfıra indirip, diyalogtan çıkınca hassasiyeti varsayılan değere döndürür
        defSensY = ySensitivity;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))            //"H" Tusu el feneri
        {
            if (flashLightObject.activeInHierarchy)
            {
                flashLightObject.SetActive(false);
            }
            else{
                flashLightObject.SetActive(true);
            }
        }
    }

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;                                 //Oyuncunun etrafina bakmasi icin
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
