using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openTabQuests : MonoBehaviour
{
    public Image backGroundQuests;
    public Image precisionQuest;
    public GameObject closeTab;
    public GameObject openTab;

    public GameObject closePrecisions;
    public GameObject[] Quests;
    private void Start()
    {
        backGroundQuests.gameObject.SetActive(false);
        closeTab.SetActive(false);
        closePrecisions.SetActive(false);

        foreach (GameObject quest in Quests)
        {
            quest.SetActive(false);
        }
    }

    private void Update()
    {
        if(fightManager.Instance.state != GameState.waitForStart)
        {
            openTab.SetActive(false);
        }
        else if(fightManager.Instance.state == GameState.waitForStart && !closeTab.activeSelf)
        {
            openTab.SetActive(true);
        }
    }

    public void openTabQuest()
    {
        backGroundQuests.gameObject.SetActive(true);
        closeTab.SetActive(true);
        openTab.SetActive(false);

        foreach (GameObject quest in Quests)
        {
            quest.SetActive(true);
        }
    }

    public void closeTabQuest()
    {
        backGroundQuests.gameObject.SetActive(false);
        closeTab.SetActive(false);
        openTab.SetActive(true);
        precisionQuest.gameObject.SetActive(false);

        closePrecisions.SetActive(false);

        foreach (GameObject quest in Quests)
        {
            quest.SetActive(false);
        }
    }
}
