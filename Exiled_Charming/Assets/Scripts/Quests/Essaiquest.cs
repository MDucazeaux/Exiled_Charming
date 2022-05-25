using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Essaiquest : MonoBehaviour
{
    public int currentQuest = 0;
    public EssaiUIquest QuestPrincipal;

    public Image FondImageQuete1;
    public Text textinfosQuete1;
    public GameObject AccepterQuest1;

    public Image fondImagerewardquete1;
    public Text  RewardQuete1;
    public GameObject butonreward1;

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
            QuestPrincipal.StartQuest("Quete 1, partie 2", 1);
        }

        if (sousQuete == 2)
        {
            fondImagerewardquete1.enabled = true;
            RewardQuete1.enabled = true;
            butonreward1.SetActive(true);
        }
        // FIN DE QUETE NUMERO 0
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        // QUETE NUMERO 0 
        if (collision.CompareTag("quete1") && retakequest == true)
        {
            FondImageQuete1.enabled = true;
            textinfosQuete1.enabled = true;
            AccepterQuest1.SetActive(true);
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
        // FIN DE QUETE NUMERO 0

        //QUETE NUMERO 1 
    }

    public void acceptQuest()
    {
        currentQuest = 1;
        QuestPrincipal.StartQuest("Quete 1, partie 1", 1);
        retakequest = false;
        FondImageQuete1.enabled = false;
        textinfosQuete1.enabled = false;
        AccepterQuest1.SetActive(false);
    }
}