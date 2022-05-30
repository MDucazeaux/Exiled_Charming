using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Update()
    {
        float dirx = Input.GetAxisRaw("Horizontal");
        float diry = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(dirx, diry ).normalized;
        rb.velocity *= Speed;
    }
    //private IEnumerator MovePlayer(Vector3 direction)
    //{
    //    isMoving = true;

    //    float elapsedTime = 0;

    //    originPos = transform.position;
    //    targetPos = originPos + direction;

        

    //    while (elapsedTime < timeForMoove)
    //    {
    //        transform.position = Vector3.Lerp(originPos, targetPos, (elapsedTime / timeForMoove));
    //        elapsedTime += Time.deltaTime;
    //        yield return null;
    //    }
    //    transform.position = targetPos;

    //    isMoving = false;
    //}
}
