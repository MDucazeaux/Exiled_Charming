using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class princessDialogue : MonoBehaviour
{
    public int dialogueChoice = -1;

    public float speed;
    public TextMeshProUGUI textZone;
    public GameObject nextText;

    private int index;
    public string[] dialogue1;
    public string[] dialogue2;
    public string[] dialogue3;
    public string[] dialogue4;

    private void Update()
    {
        switch(dialogueChoice)
        {
            case 0:
                if (textZone.text == dialogue1[index])
                {
                    nextText.SetActive(true);
                }
                break;
            case 1:
                if (textZone.text == dialogue2[index])
                {
                    nextText.SetActive(true);
                }
                break;
        }
    }
    private IEnumerator Typing()
    {
        switch(dialogueChoice)
        {
            case 0:
                foreach (char letter in dialogue1[index].ToCharArray())
                {
                    textZone.text += letter;
                    yield return new WaitForSeconds(speed);
                }
                break;
            case 1:
                foreach (char letter in dialogue2[index].ToCharArray())
                {
                    textZone.text += letter;
                    yield return new WaitForSeconds(speed);
                }
                break;
        }

    }

    public void nextSentence()
    {
        nextText.SetActive(false);
        switch(dialogueChoice)
        {
            case 0:
                if (index < dialogue1.Length - 1)
                {
                    index++;
                    textZone.text = "";
                    StartCoroutine(Typing());
                }
                else
                {
                    textZone.text = "";
                    nextText.SetActive(false);
                }
                break;
            case 1:
                if (index < dialogue2.Length - 1)
                {
                    index++;
                    textZone.text = "";
                    StartCoroutine(Typing());
                }
                else
                {
                    textZone.text = "";
                    nextText.SetActive(false);
                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "prince")
        {
            dialogueChoice = 0;
            StartCoroutine(Typing());
        }
        else if (collision.gameObject.name == "servante 1")
        {
            dialogueChoice = 1;
            StartCoroutine(Typing());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine(Typing());
        textZone.text = "";
        dialogueChoice = -1;
        index = 0;
    }
}
