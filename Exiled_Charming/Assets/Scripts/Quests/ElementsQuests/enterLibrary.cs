using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//quest element:  tell when the player entered the library to go to the next quest
public class enterLibrary : MonoBehaviour
{
    private bool isActivated = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && Essaiquest.Instance.index == 0 && !isActivated && Essaiquest.Instance.isActive)
        {
            Essaiquest.Instance.nextQuest();
            isActivated = true;
        }
    }
}
