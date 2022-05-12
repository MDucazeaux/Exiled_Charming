using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public GameObject ennemi;
    int posX, posY;
    int nbTurn = 0;
    private void Start()
    {
        posX = Random.Range(1, 20);
        posY = Random.Range(1, 10);

        transform.position = new Vector3(posX, posY, -3);
    }
    void Update()
    {
        if (ennemi.GetComponent<posEnnemiField>().nbTurn == 0)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position += new Vector3(1, 0, 0);
                ennemi.GetComponent<posEnnemiField>().nbTurn += 1;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.position += new Vector3(0, -1, 0);
                ennemi.GetComponent<posEnnemiField>().nbTurn += 1;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.position += new Vector3(-1, 0, 0);
                ennemi.GetComponent<posEnnemiField>().nbTurn += 1;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.position += new Vector3(0, 1, 0);
                ennemi.GetComponent<posEnnemiField>().nbTurn += 1;
            }
        }
        else
        {
            ennemi.GetComponent<posEnnemiField>().timerTurn -= Time.deltaTime;
        }
    }
}
