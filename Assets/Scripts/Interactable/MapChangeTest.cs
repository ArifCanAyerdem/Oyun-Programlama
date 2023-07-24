using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MapChangeTest : Interactable
{
    Animator animator;
    public GameObject mapPanel;
    private bool panelOpen = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected override void Interact()
    {
        Debug.Log(gameObject.name + " ile etkileşime geçildi!");
        if (panelOpen == false)
        {
            mapPanel.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (panelOpen == true)
        {
            mapPanel.SetActive(false);
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("doorStatus", true);
    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("doorStatus", false);
    }
}
