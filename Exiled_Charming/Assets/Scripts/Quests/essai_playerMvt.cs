using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class essai_playerMvt : MonoBehaviour
{
    public float originalSpeed = 9.0f;
    public float speed = 9.0f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 move = new Vector2(moveX, moveY);
        rb.velocity = new Vector2(move.x * speed, move.y * speed);
    }
}
