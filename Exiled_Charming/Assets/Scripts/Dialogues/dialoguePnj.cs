using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialoguePnj : MonoBehaviour
{

    private GameObject dialogueManager;

    private bool canTalk = false;

    //------------------------------------//

    public bool hasTalkedToKingOne = false;
    private int cancelQuest = 0;

    //------------------------------------//


    public string[] dialogueNPC;
    public string[] questDialogue;

    private string[] originalDialogue;
    private void Start()
    {
        dialogueManager = GameObject.Find("dialogueManager");
        originalDialogue = dialogueNPC;
    }

    private int dialogueNb = 0;
    private void Update()
    {
        if(this.gameObject.GetComponent<enemyUnit>() && canTalk && Input.GetKeyUp(KeyCode.Space))
        {
            dialogueManager.GetComponent<DialogueManager>().SetDialogue(questDialogue);
        }
        else if(canTalk && Input.GetKeyUp(KeyCode.Space) && !this.GetComponent<enemyUnit>())
        {

            if(hasTalkedToKingOne && cancelQuest == 0)
            {
                dialogueNPC = questDialogue;
                Essaiquest.Instance.nextQuest();
                cancelQuest = 1;
            }
            else if(cancelQuest != 0)
            {
                this.enabled = false;
            }

            dialogueManager.GetComponent<DialogueManager>().SetDialogue(dialogueNPC);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            canTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTalk = false;
    }
}
