using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterCombat : MonoBehaviour
{
    public gameManager gameManager;
    public List<BoxCollider2D> myColliders;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ennemi")
        {
            gameManager.state = gameState.Fight;
        }
    }
}
