using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giveClothes : MonoBehaviour
{
    public bool isActived = false;
    private int done = 0;

    public GameObject clothDisguise;
    private GameObject Player;

    private void Start()
    {
        clothDisguise.SetActive(false);
    }
    private void Update()
    {
        if(isActived && done == 0)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                clothDisguise.SetActive(true);
                Essaiquest.Instance.requirementQ4 += 1;
                done = 1;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player" & Essaiquest.Instance.index == 4 && Essaiquest.Instance.isActive)
        {
            isActived = true;
        }
    }
}
