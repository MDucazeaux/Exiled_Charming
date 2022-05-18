using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public bool PlayerTurn;
    private void Start()
    {
        PlayerTurn = false;

    }
    void Update()
    {
        // waits for the player turn to make action
        if (fightManager.Instance.state == GameState.playerTurn && PlayerTurn)
        {
            if(Input.GetKeyUp(KeyCode.Joystick1Button1) && choicesPlayer.Instance.canMove)
            {
                choicesPlayer.Instance.choice = 4;
            }

            if(Input.GetKey(KeyCode.Joystick1Button5) && !choicesPlayer.Instance.canMove)
            {
                choicesPlayer.Instance.choice = 2;
            }
            else if(Input.GetKey(KeyCode.Joystick1Button4) && !choicesPlayer.Instance.canMove)
            {
                choicesPlayer.Instance.choice = 3;
            }
            else if(Input.GetKey(KeyCode.Joystick1Button3) && !choicesPlayer.Instance.canMove)
            {
                choicesPlayer.Instance.choice = 1;
            }
            else if(Input.GetKeyUp(KeyCode.Joystick1Button1) && !choicesPlayer.Instance.canMove)
            {
                choicesPlayer.Instance.choice = 4;
            }
        }
    }

}
