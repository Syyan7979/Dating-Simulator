using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class TextUpdate : MonoBehaviour
{
    // Config Parameters
    [SerializeField] TextMeshProUGUI dialogue;
    [SerializeField] TextMeshProUGUI speaker;
    [SerializeField] States state;
    [SerializeField] Button reply1, reply2, reply3, next;
    [SerializeField] TextMeshProUGUI option1, option2, option3;

    // Initializing Variables
    string[] choices;
    int counter = 0;
    bool dialogueSizeChecker;
    string[] dialogues;

    // Start is called before the first frame update
    void Start()
    {
        TextFieldUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        TextFieldUpdate();
        DialogueCheck();
        NextAndReplies();
    }

    private void NextAndReplies()
    {
        choices = state.ChoicesReturn();
        if (dialogueSizeChecker)
        {
            next.gameObject.SetActive(true);
            reply1.gameObject.SetActive(false);
            reply2.gameObject.SetActive(false);
            reply3.gameObject.SetActive(false);
        } else
        {
            next.gameObject.SetActive(false);
            if (choices.Length == 1)
            {
                option1.text = choices[0];
                reply1.gameObject.SetActive(true);
                reply2.gameObject.SetActive(false);
                reply3.gameObject.SetActive(false);
            }
            else if (choices.Length == 2)
            {
                option1.text = choices[0];
                option2.text = choices[1];
                reply1.gameObject.SetActive(true);
                reply2.gameObject.SetActive(true);
                reply3.gameObject.SetActive(false);
            }
            else
            {
                option1.text = choices[0];
                option2.text = choices[1];
                option3.text = choices[2];
                reply1.gameObject.SetActive(true);
                reply2.gameObject.SetActive(true);
                reply3.gameObject.SetActive(true);
            }
        }
    }

    private void DialogueCheck()
    {
        dialogues = state.DialogueReturn();
        if (dialogues.Length - 1 == counter)
        {
            dialogueSizeChecker = false;
        } else
        {
            dialogueSizeChecker = true;
        }
    }

    private void TextFieldUpdate()
    {
        speaker.text = state.SpeakerReturn();
        dialogues = state.DialogueReturn();
        dialogue.text = dialogues[counter];
    }

    public void OptionOnePressed()
    {
        state = state.NextState(0);
        counter = 0;
    }

    public void OptionTwoPressed()
    {
        state = state.NextState(1);
        counter = 0;
    }

    public void OptionThreePressed()
    {
        state = state.NextState(2);
        counter = 0;
    }

    public void NextButtonPressed()
    {
        counter++;
    }
}
