using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prince : MonoBehaviour
{
    public bool EnemyTurn;
    public bool enabledTurn = true;

    //called in the fight manager if:
    //-Identity = prince
    //-state = enemyTurn
    //turn is enabled

    //else if its still the enemy turn itll know that this one isnt concerned...
    public void makeDecision() 
    {
        enabledTurn = true;

        if(EnemyTurn && enabledTurn)
        {
            this.gameObject.GetComponent<choicesIA>().choice = 0;
            this.gameObject.GetComponent<choicesIA>().canMove = true;

            enabledTurn = false;
        }
    }
}
