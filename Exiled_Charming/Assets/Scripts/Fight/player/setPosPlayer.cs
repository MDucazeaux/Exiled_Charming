using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setPosPlayer : MonoBehaviour
{
    private GameObject linkedPlayer;

    private void Start()
    {
        linkedPlayer = GameObject.Find("Player");
    }
    private void Update()
    {
        this.transform.position = new Vector3(linkedPlayer.transform.position.x, linkedPlayer.transform.position.y, linkedPlayer.transform.position.z);
    }
}
