using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainQuestManager : MonoBehaviour
{
    public questManager questManager;

    //quest 1
    public int currentNbObject = 0, nbObjectRequired = 1;

    public void firstQuest()
    {
        if(currentNbObject >= nbObjectRequired)
        {
            questManager.nextQuest = true;
        }
    }

    public void secondQuest()
    {
        Debug.Log("talk to the left guy");
    }

    public void thirdQuest()
    {
        Debug.Log("Press V");
    }
}
