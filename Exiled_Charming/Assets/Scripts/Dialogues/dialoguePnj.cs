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
    public string[] dialoguePrince1;
    public string[] dialoguePrince2;
    public string[] dialoguePrince3;
    private void Start()
    {
        dialogueManager = GameObject.Find("dialogueManager");
    }

    private int dialogueNb = 0;
    private void Update()
    {
        if(this.gameObject.GetComponent<enemyUnit>() && canTalk && Input.GetKeyUp(KeyCode.Space))
        {
            switch(dialogueNb)
            {
                case 0: dialogueManager.GetComponent<DialogueManager>().SetDialogue(dialoguePrince1); dialogueNb = 1; break;
                case 1: dialogueManager.GetComponent<DialogueManager>().SetDialogue(dialoguePrince2); dialogueNb = 2; break;
                case 2: dialogueManager.GetComponent<DialogueManager>().SetDialogue(dialoguePrince3); dialogueNb = -1; break;
            }
        }
        else if(canTalk && Input.GetKeyUp(KeyCode.Space) && !this.GetComponent<enemyUnit>())
        {
            dialogueManager.GetComponent<DialogueManager>().SetDialogue(dialogueNPC);

            if(hasTalkedToKingOne && cancelQuest == 0)
            {
                Essaiquest.Instance.nextQuest();
                cancelQuest = 1;
            }
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
