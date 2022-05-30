using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this object is made so that the it can be placed around the enemy when he is in fight only

public class setPosEnemy : MonoBehaviour
{
    public GameObject linkedPlayer;

    private void Start()
    {
    }
    private void Update()
    {
        if (fightManager.Instance.Ennemi != null)
        {
            linkedPlayer = fightManager.Instance.Ennemi;
            this.transform.position = new Vector3(linkedPlayer.transform.position.x, linkedPlayer.transform.position.y, linkedPlayer.transform.position.z);
        }
    }
}
