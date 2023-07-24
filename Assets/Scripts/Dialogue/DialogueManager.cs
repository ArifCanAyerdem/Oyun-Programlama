using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialaguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choises UI")]
    [SerializeField] private GameObject[] choices;
     private TextMeshProUGUI[] choicesText;


    private Story currentStory;
    public bool dialagueIsPlaying { get; private set; } 


  private static DialogueManager instance;

  private void Awake()
  {
    if(instance != null)
    {
        Debug.Log("Hata");
    }
    instance = this;
  }

  public static DialogueManager GetInstance(){
    return instance;
  }

  private void Start() 
  {

    dialagueIsPlaying = false;
    dialaguePanel.SetActive(false);
    choicesText = new TextMeshProUGUI[choices.Length];
    int index = 0;
    foreach (GameObject choice in choices)
    {
        choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
        index++;
    }


  }

  private void Update()
  {
    if (!dialagueIsPlaying)
    {
        return;
    }
    if(Input.GetKeyUp(KeyCode.Return))
     {
        ContinueStory();
     }
     else{Debug.Log("Sa");} 
      
  }

 public void EnterDialogueMode(TextAsset inkJSON)
 {
    currentStory = new Story(inkJSON.text);
    dialagueIsPlaying=true;
    dialaguePanel.SetActive(true);
    ContinueStory();

 }
 private IEnumerator ExitDialogueMode()
 {
    yield return new WaitForSeconds(0.2f);

    dialagueIsPlaying=false;
    dialaguePanel.SetActive(false);
    dialogueText.text = "";
 }
 private void ContinueStory()
 {
      if(currentStory.canContinue)
    {
        dialogueText.text = currentStory.Continue();
        DisplayChoices();
    }
    else 
    {
        StartCoroutine(ExitDialogueMode());
    }
 }


 private void DisplayChoices()
 {
    List<Choice> currentChoices = currentStory.currentChoices;

    if (currentChoices.Count > choices.Length)
    {
        Debug.LogError("Hataa");
    }
    
    int index = 0; 
    foreach (Choice choice in currentChoices)
    {
        choices[index].gameObject.SetActive(true);
        choicesText[index].text = choice.text;
        index++;
    }

    for (int i = index; i < choices.Length; i++)
    {
        choices[i].gameObject.SetActive(false);
    }
    StartCoroutine(SelectFirstChoice());
 }
 private IEnumerator SelectFirstChoice()
 {

    EventSystem.current.SetSelectedGameObject(null);
    yield return new WaitForEndOfFrame();
    EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
 }

 public void MakeChoice(int choiceIndex)
 {
    currentStory.ChooseChoiceIndex(choiceIndex);
    ContinueStory();
 }

}
