using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacementPlayer : MonoBehaviour
{
    private GameObject mainUser = null;

    public int type = 0;
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
    private void OnTriggerEnter2D(Collider2D collision)
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
