using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    private Vector3 originPos, targetPos;

    [HideInInspector]
    public bool isMoving;

    private float timeForMoove = 0.2f;
    void Update()
    {
        float axeX = Input.GetAxisRaw("Horizontal");
        float axeY = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.Z) && !isMoving /*&& Triggers[0].GetComponent<TriggerMove>().Collid*/ || axeY > 0 && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.up));
        }

        if (Input.GetKey(KeyCode.Q) && !isMoving /*&& Triggers[3].GetComponent<TriggerMove>().Collid*/ || axeX < 0 && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.left));
        }

        if (Input.GetKey(KeyCode.S) && !isMoving /*&& Triggers[2].GetComponent<TriggerMove>().Collid*/ || axeY < 0 && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.down));
        }

        if (Input.GetKey(KeyCode.D) && !isMoving /*&& Triggers[1].GetComponent<TriggerMove>().Collid*/ || axeX > 0 && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.right));
        }
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        originPos = transform.position;
        targetPos = originPos + direction;

        

        while (elapsedTime < timeForMoove)
        {
            transform.position = Vector3.Lerp(originPos, targetPos, (elapsedTime / timeForMoove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }
}
