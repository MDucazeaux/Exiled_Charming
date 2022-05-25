using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterLibrary : MonoBehaviour
{
    private bool isActivated = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && Essaiquest.Instance.index == 0 && !isActivated)
        {
            Essaiquest.Instance.nextQuest();
            isActivated = true;
        }
    }
}
