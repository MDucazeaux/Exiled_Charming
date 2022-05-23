using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Essaiquest : MonoBehaviour
{
    public int currentQuest = 0;
    public EssaiUIquest QuestPrincipal;

    private int sousQuete = 0;
    private int finishQuest = 0;
    private bool retakequest = true; private bool retakequest1 = true; private bool retakequest2 = true; private bool retakequest3 = true;
    
    void Start()
    {
    
    }


    void Update()
    {
        if (sousQuete == 1)
        {
            QuestPrincipal.StartQuest("Partie 2", 1);
        }

        if (sousQuete == 2)
        {
            QuestPrincipal.StartQuest("Partie 3", 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("quete1") && retakequest == true)
        {
            currentQuest = 1;
            QuestPrincipal.StartQuest("Quete 1", 1);
            retakequest = false;
            Debug.Log("Vous avez besoin de ramasser un gros carré sur la map");
        }

        if (collision.CompareTag("item1") && currentQuest == 1 && retakequest1 == true)
        {
            QuestPrincipal.FinishQuest(1);
            retakequest1 = false;
            sousQuete = 1;
        }

        if (collision.CompareTag("item2") && sousQuete == 1)
        {
            QuestPrincipal.FinishQuest(1);
            sousQuete = 2;
        }

        //if (collision.CompareTag("quete2") && finishQuest == 1 && retakequest1 == true)
        //{
        //    QuestPrincipal.StartQuest("partie 2");
        //    retakequest1 = false;
        //    currentQuest = 2;
        //    Debug.Log("idem");
        //}


        //if (collision.CompareTag("quete3") && finishQuest == 2 && retakequest2 == true)
        //{
        //    QuestPrincipal.StartQuest("Quêtes 3");
        //    currentQuest = 3;
        //    retakequest2 = false;
        //    Debug.Log("idem2");
        //}

        //if (collision.CompareTag("item3") && currentQuest == 3)
        //{
        //    QuestPrincipal.FinishQuest(3);
        //    collision.gameObject.SetActive(false);
        //    finishQuest = 3;
        //}
    }
}