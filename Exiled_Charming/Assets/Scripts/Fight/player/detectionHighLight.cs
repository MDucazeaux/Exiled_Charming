using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionHighLight : MonoBehaviour
{
    public GameObject Player;

    private void Update()
    {
        float x = Player.transform.position.x;
        float y = Player.transform.position.y;

        transform.position = new Vector3(x, y, -0.1f);

    }
}
