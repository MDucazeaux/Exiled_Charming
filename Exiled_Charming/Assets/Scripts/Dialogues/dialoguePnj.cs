using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the dialogue is set in the inspector but it contains the main dialogue of the npc or its dialogue quest.
public class dialoguePnj : MonoBehaviour
{

    private GameObject dialogueManager;
    private GameObject guardAppearance;
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
        guardAppearance = GameObject.Find("LibraryGuard");
        originalDialogue = dialogueNPC;
    }

    private void Update()
    {
        if (this.gameObject.GetComponent<enemyUnit>() && canTalk && Input.GetKeyUp(KeyCode.Space))
        {
            dialogueManager.GetComponent<DialogueManager>().SetDialogue(questDialogue);

            if(this.tag == "Prince")
            {
                this.tag = "ennemi";
            }


        }
        else if(canTalk && Input.GetKeyUp(KeyCode.Space) && !this.GetComponent<enemyUnit>())
        {
            if (hasTalkedToKingOne && cancelQuest == 0)
            {
                dialogueNPC = questDialogue; 
                Debug.Log(guardAppearance.name);
                Debug.Log(dialogueManager.GetComponent<DialogueManager>().index);
            }

            dialogueManager.GetComponent<DialogueManager>().SetDialogue(dialogueNPC);
        }

        if(hasTalkedToKingOne && dialogueManager.GetComponent<DialogueManager>().index >= 6)
        {
                guardAppearance.GetComponent<SpriteRenderer>().enabled = true;
                Essaiquest.Instance.nextQuest();
                this.enabled = false;
                cancelQuest = 1;
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
        if(collision.gameObject.tag == "Player")
        {
            canTalk = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canTalk = false;
    }
}
