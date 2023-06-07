using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Journal : MonoBehaviour
{
    public static Journal instance;
    public TMP_InputField inputField;

    public string journalText;
    public TMP_Text textArea;

    public List<string> journalTextList;
    private void Start()
    {
        instance = this;
        journalTextList = new List<string>
        {
            "Hello journal",
            "Let's go explore"
        };
        ListJournals();
    }

    private void OnEnable()
    {
        ListJournals();
        textArea.text = journalText;
        inputField.text = "";
        inputField.ActivateInputField();
    }

    public void ListJournals()
    {
        journalText = "";
        foreach (string journal in journalTextList)
        {
            journalText = journalText + journal + "\n";
        }
    }

    //public void ListJournals()
    //{
    //    journalText = "";
    //    foreach (string journal in journalTextList)
    //    {
    //        journalText = journalText + journal + "\n";
    //    }
    //}

    public void OnSendNote()
    {
        if(inputField.text != "j")
        {
            journalTextList.Add(inputField.text);
            journalText = journalText + inputField.text + "\n";
            textArea.text = journalText;
            inputField.text = "";
        }
    }
}
