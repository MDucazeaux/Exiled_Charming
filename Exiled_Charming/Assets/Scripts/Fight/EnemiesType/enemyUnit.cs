using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this component permite to verify that its the enemy turn and not the player.

public class enemyUnit : MonoBehaviour
{
    public bool EnemyTurn;
    public bool enabledTurn = true;

    //called in the fight manager if:
    //-Identity = enemyUnit
    //-state = enemyTurn
    //turn is enabled

    //else if its still the enemy turn itll know that this one isnt concerned...
    public void makeDecision() 
    {
        enabledTurn = true;

        if(EnemyTurn && enabledTurn)
        {
            this.gameObject.GetComponent<choicesIA>().choice = 0;
            enabledTurn = false;
        }
    }
}
