using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerChoiceManager : MonoBehaviour
{
    public static playerChoiceManager Instance;

    public choicePlayer choice;

    private void Awake()
    {
        Instance = this;
    }
    public void makeChoice(choicePlayer pick)
    {
        choice = pick;

        switch(choice)
        {
            case choicePlayer.waitforchoice:
                break;
            case choicePlayer.move:
                break;
            case choicePlayer.heal:
                break;
            case choicePlayer.attack1:
                break;
            case choicePlayer.attack2:
                break;
            case choicePlayer.pass:
                break;
        }

    }
}

public enum choicePlayer
{
    waitforchoice,
    move,
    heal,
    attack1,
    attack2,
    pass
}
