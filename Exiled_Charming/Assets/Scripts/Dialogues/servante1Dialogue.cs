using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class servante1Dialogue : MonoBehaviour
{
    private GameObject dialogueManager;
    public bool enableMainDialogue = false;

    public string[] dialogue;

    public int typeDialogue = 0; //0 means that its the main quest dialogue and 1 will be the normal language for now

    private void Start()
    {
        dialogueManager = GameObject.Find("dialogueManager");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (enableMainDialogue)
            {
                dialogueManager.GetComponent<DialogueManager>().SetDialogue(dialogue);
                typeDialogue += 1;
                enableMainDialogue = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" &&  typeDialogue == 0)
        {
            enableMainDialogue = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        enableMainDialogue = false;
    }
}
