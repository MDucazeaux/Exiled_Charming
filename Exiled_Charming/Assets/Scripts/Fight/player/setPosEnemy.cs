using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
