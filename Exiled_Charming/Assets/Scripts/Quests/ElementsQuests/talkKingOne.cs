using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(collision.gameObject.tag == "Player" && Essaiquest.Instance.index == 1)
        {
            isActivated = true;
        }
    }
}
