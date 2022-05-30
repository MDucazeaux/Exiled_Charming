using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//functions to enable and disable elements during the fight also working with a controller
public class playermovement : MonoBehaviour
{
    public bool PlayerTurn;

    void Update()
    {
    }

    public void makeMovement(Vector3 nextMove)
    {
        this.gameObject.transform.position += nextMove;

        choicesPlayer.Instance.Move.gameObject.SetActive(false);
        choicesPlayer.Instance.Atk1.gameObject.SetActive(true);
        choicesPlayer.Instance.Atk2.gameObject.SetActive(true);
        choicesPlayer.Instance.Heal.gameObject.SetActive(true);

        choicesPlayer.Instance.deplacementsPlayer.SetActive(false);

        choicesPlayer.Instance.choice = -1;
        choicesPlayer.Instance.canMove = false;
    }

    public void showMovementAllowed(GameObject supportMovementsTiles)
    {
        if(Input.GetAxis("trigger right") > 0)
        {
            supportMovementsTiles.SetActive(true);
        }
    }
    public void selectChoice()
    {
        if (Input.GetKeyUp(KeyCode.Joystick1Button1) && choicesPlayer.Instance.canMove)
        {
            choicesPlayer.Instance.choice = 4;
        }

        if (Input.GetAxis("trigger right") > 0)
        {
            choicesPlayer.Instance.choice = 0;
        }

        if (Input.GetKey(KeyCode.Joystick1Button5) && !choicesPlayer.Instance.canMove)
        {
            choicesPlayer.Instance.choice = 2;
        }
        if (Input.GetKey(KeyCode.Joystick1Button4) && !choicesPlayer.Instance.canMove)
        {
            choicesPlayer.Instance.choice = 3;
        }
        if (Input.GetKey(KeyCode.Joystick1Button3) && !choicesPlayer.Instance.canMove)
        {
            choicesPlayer.Instance.choice = 1;
        }
        if (Input.GetKeyUp(KeyCode.Joystick1Button1) && !choicesPlayer.Instance.canMove)
        {
            choicesPlayer.Instance.choice = 4;
        }
    }

}
