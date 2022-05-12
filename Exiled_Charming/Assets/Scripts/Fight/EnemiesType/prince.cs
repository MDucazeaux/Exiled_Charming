using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prince : MonoBehaviour
{
    public bool EnemyTurn;
    public bool enabledTurn = true;

    public void makeDecision()
    {
        if(EnemyTurn && enabledTurn)
        {
            this.gameObject.GetComponent<choicesIA>().choice = 0;
            this.gameObject.GetComponent<choicesIA>().canMove = true ;

            enabledTurn = false;
        }
    }
}
