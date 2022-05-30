using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this component make the player moves depending on where the user wants it to go
public class Movements : MonoBehaviour
{
    private Vector3 originPos, targetPos;

    [HideInInspector]
    public bool IsMoving;
    private Rigidbody2D rb;
    public float Speed = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(Speed,0));
        }
        if(Input.GetKey(KeyCode.Q))
        {
            rb.AddForce(new Vector2(-Speed,0));
        }
        if(Input.GetKey(KeyCode.Z))
        {
            rb.AddForce(new Vector2(0,Speed));
        }
        if(Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector2(0,-Speed));
        }
    }
}
