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

    private void Update()
    {
        if (this.gameObject.GetComponent<enemyUnit>() && canTalk && Input.GetKeyUp(KeyCode.Space))
        {
            dialogueManager.GetComponent<DialogueManager>().SetDialogue(questDialogue);

            if(this.tag == "Prince" && dialogueManager.GetComponent<DialogueManager>().index == dialogueNPC.Length)
            {
                this.tag = "ennemi";
            }


        }
        else if(canTalk && Input.GetKeyUp(KeyCode.Space) && !this.GetComponent<enemyUnit>())
        {
            if (hasTalkedToKingOne && cancelQuest == 0)
            {
                dialogueNPC = questDialogue;
                Essaiquest.Instance.nextQuest();
                this.enabled = false;
                cancelQuest = 1;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && this.tag == "Prince")
        {
            canTalk = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canTalk = false;
    }
}
