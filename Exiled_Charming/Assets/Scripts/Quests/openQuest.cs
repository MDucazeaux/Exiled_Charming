using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this component will do the organisation between the quest buttons
public class openQuest : MonoBehaviour
{
    public GameObject questPrecision;
    public GameObject closeQuests;
    public void Start()
    {
        questPrecision.SetActive(false);
        closeQuests.SetActive(false);
    }
    public void showQuest()
    {
        questPrecision.SetActive(true);
        closeQuests.SetActive(true);
    }

    public void closeQuest()
    {
        questPrecision.SetActive(false);
        closeQuests.SetActive(false);

    }
}
