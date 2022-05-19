using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questInventory : MonoBehaviour
{
    public mainQuestManager mainQuestManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //exemple quest1

        if(collision.gameObject.name == "object")
        {
            collision.gameObject.SetActive(false);
            mainQuestManager.currentNbObject += 1;
        }
    }
}
