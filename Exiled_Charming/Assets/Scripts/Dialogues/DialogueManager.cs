using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//make the dialogue lines go after each other (when one has ended, itll check if there is another line after, if not the player can stop the dialogue)
public class DialogueManager : MonoBehaviour
{
    public float speed;

    public TextMeshProUGUI textZone;

    public GameObject panels;
    public GameObject InventoryUI;
    public GameObject QuestsUI;
    public GameObject nextText;

    public int index;
    private string[] dialogue;

    private bool talkEnabled = true;

    private string[] newdialogue;

    public void SetDialogue(string[] _dialogue)
    {
        newdialogue = _dialogue;

        dialogue = newdialogue;

        if (talkEnabled)
        { 
            panels.SetActive(true);
            StartCoroutine(Typing());
            talkEnabled = false;
        }

    }

    private void Start()
    {
        panels.SetActive(false);
        nextText.SetActive(false);
    }
    private void Update()
    {

        if (dialogue != null)
        if(textZone.text == dialogue[index])
        {
            nextText.SetActive(true);
        }

        if(talkEnabled)
        {
            Time.timeScale = 1f;
            QuestsUI.SetActive(true);
            InventoryUI.SetActive(true);
        }
        else if(!talkEnabled)
        {
            Time.timeScale = 0f;
            QuestsUI.SetActive(false);
            InventoryUI.SetActive(false);
        }
    }
    private IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            textZone.text += letter;
            yield return new WaitForSecondsRealtime(speed);
        }
    }

    public void nextSentence()
    {
        nextText.SetActive(false);

        if (index < dialogue.Length - 1)
        {
            textZone.text = "";
            index++;
            StartCoroutine(Typing());
        }
        else
        {
            talkEnabled = true;
            textZone.text = "";
            index = 0;

            panels.SetActive(false) ;
            nextText.SetActive(false);
        }
    }
}
