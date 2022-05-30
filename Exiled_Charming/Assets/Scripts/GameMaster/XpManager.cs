using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpManager : MonoBehaviour
{
    public int Level;
   
    private float xp;
    private float maxxp;
    void Start()
    {
        maxxp = 10f;
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.GetComponent<Movements>())
        //{

        if (xp >= maxxp)
        {
            Level += 1;
            maxxp *= 2;
            xp = 0;

        }

        //}





    }
}
