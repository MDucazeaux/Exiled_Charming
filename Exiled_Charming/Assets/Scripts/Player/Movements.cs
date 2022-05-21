using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    private Vector3 originPos, targetPos;
    private Vector2 respawnPoint;

    private bool isMoving;

    private float timeForMoove = 0.2f;
    void Update()
    {
<<<<<<< HEAD

        if (SaveManager.instance.HasLoaded)
        {
           // add saved HP//
            respawnPoint = SaveManager.instance.ActiveSave.RespawnPositionSaved;
            transform.position = SaveManager.instance.ActiveSave.RespawnPositionSaved;
            SaveManager.instance.HasLoaded = false;
        }

        SaveManager.instance.ActiveSave.RespawnPositionSaved = transform.position;

        if (Input.GetKey(KeyCode.Z) && !isMoving)
=======
        float axeX = Input.GetAxisRaw("Horizontal");
        float axeY = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.Z) && !isMoving /*&& Triggers[0].GetComponent<TriggerMove>().Collid*/ || axeY > 0 && !isMoving)
>>>>>>> Mapping
        {
            StartCoroutine(MovePlayer(Vector3.up));
        }

<<<<<<< HEAD
        if (Input.GetKey(KeyCode.Q) && !isMoving)
=======
        if (Input.GetKey(KeyCode.Q) && !isMoving /*&& Triggers[3].GetComponent<TriggerMove>().Collid*/ || axeX < 0 && !isMoving)
>>>>>>> Mapping
        {
            StartCoroutine(MovePlayer(Vector3.left));
        }

<<<<<<< HEAD
        if (Input.GetKey(KeyCode.S) && !isMoving)
=======
        if (Input.GetKey(KeyCode.S) && !isMoving /*&& Triggers[2].GetComponent<TriggerMove>().Collid*/ || axeY < 0 && !isMoving)
>>>>>>> Mapping
        {
            StartCoroutine(MovePlayer(Vector3.down));
        }

<<<<<<< HEAD
        if (Input.GetKey(KeyCode.D) && !isMoving)
=======
        if (Input.GetKey(KeyCode.D) && !isMoving /*&& Triggers[1].GetComponent<TriggerMove>().Collid*/ || axeX > 0 && !isMoving)
>>>>>>> Mapping
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
