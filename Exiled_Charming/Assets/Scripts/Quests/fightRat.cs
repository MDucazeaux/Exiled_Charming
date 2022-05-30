using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the player need to fight a rat during the tutorial and this component will permite to set the next quest
public class fightRat : MonoBehaviour
{
    public bool isActivated = false;

    private void Update()
    {
        if(isActivated)
        {
            if(this.gameObject.name == "rat" && this.GetComponent<HpManager>().Hp <= 0)
            {
                Essaiquest.Instance.nextQuest();
                isActivated = false;
            }
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
