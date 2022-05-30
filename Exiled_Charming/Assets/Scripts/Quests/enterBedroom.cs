using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//is set on  a trigger that is in the bedroom and get activated when the quest ask the player to go in his bedroom
public class enterBedroom : MonoBehaviour
{
    private bool isActivated = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Essaiquest.Instance.index == 2 && !isActivated && Essaiquest.Instance.isActive)
        {
            Essaiquest.Instance.nextQuest();
            isActivated = true;
        }
    }
}
