using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//player need to get money in a quest so this object is set in his piggy bank and if he interacts with it hell get gold coins
public class getMoneyTirelire : MonoBehaviour
{
    public bool isActived = false;
    private int done = 0;

    private void Start()
    {
    }
    private void Update()
    {
        if (isActived && done == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Ive got money");
                Essaiquest.Instance.requirementQ4 += 1;
                done = 1;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" & Essaiquest.Instance.index == 4 && Essaiquest.Instance.isActive)
        {
            isActived = true;
        }
    }
}
