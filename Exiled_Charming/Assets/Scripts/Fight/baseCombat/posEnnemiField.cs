using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posEnnemiField : MonoBehaviour
{
    public bool EnemyTurn;

    public int nbChoice = 1;

    private void Awake()
    {
    }
    void Start()
    {
    }

    public void makeDecision()
    {
        if(EnemyTurn)
        {
            this.gameObject.GetComponent<choicesIA>().choice = 0;
        }
    }

}
