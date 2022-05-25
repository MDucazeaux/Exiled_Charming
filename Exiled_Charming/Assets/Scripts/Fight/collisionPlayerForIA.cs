using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionPlayerForIA : MonoBehaviour
{
    private GameObject IA;

    private void Update()
    {
        if(fightManager.Instance.Ennemi != null)
            IA = fightManager.Instance.Ennemi;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IA.GetComponent<attacksIA>().colliderPlayer = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IA.GetComponent<attacksIA>().colliderPlayer = null;
    }
}
