using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightRat : MonoBehaviour
{
    public bool isActivated = false;

    private void Update()
    {
        if(isActivated)
        {
            Essaiquest.Instance.nextQuest();
            isActivated = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && Essaiquest.Instance.index == 1)
        {
            this.gameObject.tag = "ennemi";
            isActivated = true;
        }
    }
}
