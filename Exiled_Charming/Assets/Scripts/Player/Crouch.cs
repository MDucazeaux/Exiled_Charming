using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crouch : MonoBehaviour
{
    public RawImage DarkCalque;

    void Start()
    {
        Color c = DarkCalque.material.color;
        c.a = 0f;
        DarkCalque.material.color = c;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Color c = DarkCalque.material.color;
            c.a = 100f;
            DarkCalque.material.color = c;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Color c = DarkCalque.material.color;
            c.a = 0f;
            DarkCalque.material.color = c;
        }
    }
}
