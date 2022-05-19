using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionPlayerForIA : MonoBehaviour
{
    public attacksIA IA;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IA.colliderPlayer = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IA.colliderPlayer = null;
    }
}
