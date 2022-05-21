using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMove : MonoBehaviour
{
    public bool Collid = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.IsTouchingLayers(20))
        {
            Collid = true;
        }
        else
        {
            Collid = false;
        }
    }
}
