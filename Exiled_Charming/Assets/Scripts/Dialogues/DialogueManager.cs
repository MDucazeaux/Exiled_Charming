using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public float speed;

    public TextMeshProUGUI textZone;
    public GameObject nextText;

    private int index;
    private string[] dialogue;

    public bool talkEnabled = true;

    private string[] newdialogue;


    public void SetDialogue(string[] _dialogue)
    {
        newdialogue = _dialogue;

        if (talkEnabled)
        {
            StartCoroutine(Typing());
            talkEnabled = false;
        }

    }

    private void Update()
    {
        if(dialogue != null)
        if(textZone.text == dialogue[index])
        {
            nextText.SetActive(true);
        }
        if(Input.GetMouseButtonDown(0))
        {
            speed = 0.01f;
        }
        else
        {
            speed = 0.05f;
        }
    }
    private IEnumerator Typing()
    {
        dialogue = newdialogue;
        foreach (char letter in dialogue[index].ToCharArray())
        {
            textZone.text += letter;
            yield return new WaitForSeconds(speed);
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
            nextText.SetActive(false);
        }
    }
}
