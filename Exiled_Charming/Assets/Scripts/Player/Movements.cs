using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    private Vector3 originPos, targetPos;

    [HideInInspector]
    public bool isMoving;
    private Rigidbody2D rb;
    public float speed = 10f;
    private int timeForMoove;

    new Vector2 dir;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        

    }

    private void FixedUpdate()
    {

        if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(7 - rb.velocity.x, 0));
        }

        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddForce(new Vector2(-7 - rb.velocity.x, 0));
        }

        if (Input.GetKey(KeyCode.Z))
        {
            rb.AddForce(new Vector2(0, 7 - rb.velocity.y));
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector2(0, -7 - rb.velocity.y));
        }
    }
}
