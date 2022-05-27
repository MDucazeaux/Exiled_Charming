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

    public GameObject inventoryUI;
    private int force;

    new Vector2 dir;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        if(inventoryUI.activeSelf)
        {
            force = 0;
        }
        else if(!inventoryUI.activeSelf)
        {
            force = 7;
        }
    }

    private void FixedUpdate()
    {
        if (force > 0)
        {
            if (Input.GetKey(KeyCode.D) || dir.x > 0)
            {
                rb.AddForce(new Vector2(force - rb.velocity.x, 0));
            }

            if (Input.GetKey(KeyCode.Q) || dir.x < 0)
            {
                rb.AddForce(new Vector2(-force - rb.velocity.x, 0));
            }

            if (Input.GetKey(KeyCode.Z) || dir.y > 0)
            {
                rb.AddForce(new Vector2(0, force - rb.velocity.y));
            }

            if (Input.GetKey(KeyCode.S) || dir.y < 0)
            {
                rb.AddForce(new Vector2(0, -force - rb.velocity.y));
            }
        }
    }
}
