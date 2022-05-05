using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posPlayerOnField : MonoBehaviour
{
    public static posPlayerOnField instance;
    int posX, posY;
    private void Start()
    {
        posX = Random.Range(1, 20);
        posY = Random.Range(1, 10);

        transform.position = new Vector3(posX, posY, 0);
    }
}
