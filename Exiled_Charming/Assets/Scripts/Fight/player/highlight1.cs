using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//highlight appears when the enemies are in the player range

public class highlight1 : MonoBehaviour
{
    private GameObject Player;
    public GameObject colliderGO = null; //empty game object that will be initialized after through collision

    public bool enableAttack; //will tell if the player will be able to attack it or not
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<attackType>().gameObject;

        enableAttack = false; //set the attack permission to false since colliderGO is empty
    }

    private void Update()
    {
        if (colliderGO == null)
        {
            enableAttack = false; //there is nobody in colliderGO so its useless to attack
        }

        if (fightManager.Instance.state == GameState.playerTurn && choicesPlayer.Instance.choice == 2)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }


    //===================================================================================//

    private void OnCollisionStay2D(Collision2D collision)
    {
        //search a collision with a game object "ennemi" else it will ignore it
        if (collision.gameObject.tag == "ennemi")
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;//disable the range gameobject visual since there is someone in range(enemy in range here)

            colliderGO = collision.gameObject; //define the variable colliderGO so that we can use its variables(positions, colliders, etc...)

        }
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        //when we leave this game object collider,we set the colliderGO to null since there is nothing in it.
        colliderGO = null;

        this.gameObject.GetComponent<SpriteRenderer>().enabled = true; //enable the symbol to show the player's range (enabled if enemy out of range)
    }

    private void OnMouseDown()
    {
        Debug.Log(gameObject.name);
        if (colliderGO != null && choicesPlayer.Instance.choice == 2)
        {
            Player.GetComponent<attackType>().tile = colliderGO;
            Player.GetComponent<attackType>().atkNb = 1;
        }

        if (colliderGO == null && choicesPlayer.Instance.choice == 2)
        {
            Player.GetComponent<attackType>().emptyTile();
        }
    }
}
