using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public bool PlayerTurn;
    float posX, posY;

    private void Awake()
    {
    }
    private void Start()
    {
        PlayerTurn = false;
        //define where the player spawns on the map
        posX = Random.Range(1, 20);
        posY = Random.Range(1, 10);

    }
    void Update()
    {
        // waits for the player turn to make action
        if(fightManager.Instance.state == GameState.playerTurn && PlayerTurn)
        {
            //player keyboard controls

            
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                choicesPlayer.Instance.pickHeal();
            }
            
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                choicesPlayer.Instance.pickAttack1();
            }
            
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                choicesPlayer.Instance.pickAttack2();
            }

            if(Input.GetKeyDown(KeyCode.G))
            {
                choicesPlayer.Instance.pickPass();
            }

            //player controller controls
        }
    }

}
