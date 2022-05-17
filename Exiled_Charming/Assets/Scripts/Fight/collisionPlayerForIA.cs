using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionPlayerForIA : MonoBehaviour
{
    public attacksIA IA;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("yes collision");
            IA.colliderPlayer = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IA.colliderPlayer = null;
    }
}
