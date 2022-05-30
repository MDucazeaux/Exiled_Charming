using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this component is placed on a game object that needs to be around the player in fight
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
