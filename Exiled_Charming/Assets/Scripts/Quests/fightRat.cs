using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the player need to fight a rat during the tutorial and this component will permite to set the next quest
public class fightRat : MonoBehaviour
{
    public bool isActivated = false;
    public gameManager gameManager;

    private void Update()
    {
        if(isActivated)
        {
            Essaiquest.Instance.nextQuest();
            isActivated = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && Essaiquest.Instance.index == 1)
        {
            this.gameObject.tag = "ennemi";
            fightManager.Instance.Ennemi = this.gameObject;
            gameManager.updateState(gameState.Fight);
            isActivated = true;
        }
    }
}
