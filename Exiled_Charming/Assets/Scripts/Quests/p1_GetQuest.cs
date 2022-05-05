using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1_GetQuest : MonoBehaviour
{
    public questManager questManager;
    public int questNb;

    private void Update()
    {
        if(questManager.currentQuest == 2)
        {
            if(Input.GetKeyDown(KeyCode.V))
            {
                questManager.nextQuest = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "player" && questManager.currentQuest == questNb)
        {
            questManager.nextQuest = true;
        }
    }

}
