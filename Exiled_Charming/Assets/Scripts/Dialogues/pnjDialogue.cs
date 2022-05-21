using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pnjDialogue : MonoBehaviour
{
    private GameObject dialogueManager;

    public string[] dialogue;
    public bool talkEnable = false;
    private void Start()
    {
        dialogueManager = GameObject.Find("dialogueManager");
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && talkEnable)
        {
            dialogueManager.GetComponent<DialogueManager>().SetDialogue(dialogue);
            talkEnable = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            talkEnable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        talkEnable = false;
    }
}
