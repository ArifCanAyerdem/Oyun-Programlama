using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC_Dialog : MonoBehaviour
{
    public PlayerLook PlayerLookSc;
    public AtesEtme AtesEtmeSc;

    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public TMP_Text button1Text;
    public TMP_Text button2Text;
    public string[] dialogue;
    public string[] button1Texts;
    public string[] button2Texts;
    private int index = 0;

    public GameObject[] contButtons;
    public float wordSpeed;
    public bool playerIsClose;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerIsClose)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            PlayerLookSc.xSensitivity = 0f;
            PlayerLookSc.ySensitivity = 0f;
            AtesEtmeSc.AtesEdebilir = false;

            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if (dialogueText.text == dialogue[index])
        {
            button1Text.text = button1Texts[index];
            button2Text.text = button2Texts[index];

            contButtons[0].SetActive(true);
            contButtons[1].SetActive(true);
        }
    }

    public void zeroText() //DIYALOG BITIRICI
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        Cursor.visible = false;
        PlayerLookSc.xSensitivity = PlayerLookSc.defSensX;
        PlayerLookSc.ySensitivity = PlayerLookSc.defSensY;
        AtesEtmeSc.AtesEdebilir = true;
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        contButtons[0].SetActive(false);
        contButtons[1].SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
