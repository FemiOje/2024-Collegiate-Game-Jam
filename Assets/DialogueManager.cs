using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    [Header("Dialogue UI")]
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextAsset inkJSON;
    private Story currentStory;
    private bool isStoryPlaying;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is already an instance of DialogueManager.");
        }

        instance = this;
    }

    private void Start()
    {
        isStoryPlaying = false;
        dialoguePanel.SetActive(false);
        EnterDialogueMode();
    }

    private void Update()
    {
        // if (InputManager.GetInstance().GetSubmitPressed()){
        //     ContinueStory();
        // }
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    public void EnterDialogueMode()
    {
        isStoryPlaying = true;
        currentStory = new Story(inkJSON.text);
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    public void ExitDialogueMode()
    {
        isStoryPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    public void ContinueStory(){
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            ExitDialogueMode();
        }
    }
}
