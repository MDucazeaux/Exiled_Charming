using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//highlight appears when the enemies are in the player range

public class highlight2 : MonoBehaviour
{
    private GameObject Player;

    private GameObject colliderGO = null; //empty game object that will be initialized after through collision

    public GameObject playerSelector;

    private Color originalColor;
    public bool enableAttack; //will tell if the player will be able to attack it or not
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<attackType>().gameObject;
        enableAttack = false; //set the attack permission to false since colliderGO is empty
        originalColor = playerSelector.GetComponent<SpriteRenderer>().color;//will permite to go back on the original color when the player finished selecting its tile to attack on
    }

    private void Update()
    {
        if (colliderGO == null)
        {
            enableAttack = false; //there is nobody in colliderGO so its useless to attack
        }
        else
        {
            enableAttack = true;
        }

        if (fightManager.Instance.state == GameState.playerTurn && choicesPlayer.Instance.choice == 3)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }


    //===================================================================================//

    private void OnCollisionEnter2D(Collision2D collision)
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



    private void OnMouseEnter()
    {
        if (this.gameObject.GetComponent<SpriteRenderer>().enabled == true)
            playerSelector.SetActive(true);// player can see which tile he will select
    }



    private void OnMouseExit()
    {
        if (this.gameObject.GetComponent<SpriteRenderer>().enabled == true)
            playerSelector.SetActive(false); //player out of the tile so we disable the playerSelector tile so that the player knows which tile his mouse's on
    }



    private void OnMouseDown()
    {
        playerSelector.GetComponent<SpriteRenderer>().color = Color.green; //will show that the player valided the tile

        if (colliderGO != null)
        {
            Player.GetComponent<attackType>().tile = colliderGO;
            Player.GetComponent<attackType>().atkNb = 2;
        }

        if (this.gameObject.GetComponent<SpriteRenderer>().enabled == true && colliderGO == null)
        {
            Player.GetComponent<attackType>().emptyTile();
        }
    }



    private void OnMouseUp()
    {
        if (this.gameObject.GetComponent<SpriteRenderer>().enabled == true)
            playerSelector.GetComponent<SpriteRenderer>().color = originalColor;// will unrelease the touch so that the tile doesnt stay green
        else playerSelector.GetComponent<SpriteRenderer>().enabled = false;
    }
}
