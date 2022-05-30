using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this object is set on an object that is placed around the player that will detect the collisions and tell the player if he can move toward the direction he wants to or not.
public class deplacementPlayer : MonoBehaviour
{
    private void Update()
    {
        if(fightManager.Instance.state == GameState.playerTurn && !choicesPlayer.Instance.canMove)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Border" || collision.gameObject.tag == "ennemi")
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
