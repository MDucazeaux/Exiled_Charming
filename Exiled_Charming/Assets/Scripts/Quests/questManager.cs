using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//essai main quest
public class questManager : MonoBehaviour
{
    public mainQuestManager mqManager;
    public int currentQuest,followingQuest;
    public bool nextQuest;

    private void Update()
    {
        followingQuest = currentQuest + 1;

        switch(currentQuest)
        {
            case 0:
                mqManager.firstQuest();
                break;
            case 1:
                mqManager.secondQuest();
                break;
            case 2:
                mqManager.thirdQuest();
                break;
        }

        if(nextQuest)
        {
            addQuest();

            if(currentQuest > followingQuest)
            {
                currentQuest = currentQuest;
            }
            else
            {
                addQuest();
                followingQuest += 1;
            }
            nextQuest = false;
        }
    }

    void addQuest()
    {
        currentQuest += 1 ;
    }
}
