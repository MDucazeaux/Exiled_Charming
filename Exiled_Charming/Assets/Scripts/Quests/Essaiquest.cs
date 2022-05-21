using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essaiquest : MonoBehaviour
{

    private int currentQuest = 0;


    private int finishQuest = 0;
    
    void Start()
    {

    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("quete1"))
        {
            currentQuest = 1;
            Debug.Log("Vous avez besoin de ramasser un gros carré sur la map");    
        }


        if (collision.CompareTag("quete2") && finishQuest == 1) 
        {
            currentQuest = 2;
            Debug.Log("idem");
        }


        if (collision.CompareTag("quete3") && finishQuest == 2)
        {
            currentQuest = 3;
            Debug.Log("idem2");
        }


        if (collision.CompareTag("item1") && currentQuest == 1) 
        {
            collision.gameObject.SetActive(false);
            finishQuest = 1;
        }


        if (collision.CompareTag("item2") && currentQuest == 2)
        {
            collision.gameObject.SetActive(false);
            finishQuest = 2;
        }


        if (collision.CompareTag("item3") && currentQuest == 3)
        {
            collision.gameObject.SetActive(false);
            finishQuest = 3;
        }
    }

}