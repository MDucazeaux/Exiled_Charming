using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highlightSet : MonoBehaviour
{
    public bool Active;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
