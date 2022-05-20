using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class princesseDialogue : MonoBehaviour
{

    private GameObject dialogueManager;

    private void Start()
    {
        dialogueManager = GameObject.Find("dialogueManager");
    }
    public string[] mainDialogue;
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.K))
         dialogueManager.GetComponent<DialogueManager>().SetDialogue(mainDialogue);
    }
}
