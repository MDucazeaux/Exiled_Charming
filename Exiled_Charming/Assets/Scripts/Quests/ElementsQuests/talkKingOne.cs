using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//will set the next quest when the player has talked to the king if it was asked in the quest
public class talkKingOne : MonoBehaviour
{
    public bool isActivated = false;
    private void Update()
    {
        if(isActivated)
        {
            this.GetComponent<dialoguePnj>().hasTalkedToKingOne = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && Essaiquest.Instance.index == 3 && Essaiquest.Instance.isActive)
        {
            isActivated = true;
        }
    }
}
