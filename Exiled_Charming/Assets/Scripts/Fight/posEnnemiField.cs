using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posEnnemiField : MonoBehaviour
{
    public GameObject h, h1, h2, h3;
    public static posEnnemiField instance;
    int posX, posY;
    int randomMovement;
    public int nbTurn = 1;
    public float timerTurn = 2f;

    void Start()
    {
        posX = Random.Range(1, 20);
        posY = Random.Range(1, 10);

        transform.position = new Vector3(posX, posY, -3);
    }

    private void Update()
    {
        randomMovement = Random.Range(0, 5);

        if(timerTurn <= 0 && nbTurn > 0)
        switch(randomMovement)
        {
            case 0:
                if(h.GetComponent<SpriteRenderer>().enabled)
                {
                    transform.position += new Vector3(0, 1, 0);
                    nbTurn -= 1;
                    timerTurn = 2f;
                }
                else
                    randomMovement = Random.Range(0, 5);
                break;

            case 1:
                if (h1.GetComponent<SpriteRenderer>().enabled)
                {
                    transform.position += new Vector3(0, -1, 0);
                    nbTurn -= 1;
                        timerTurn = 2f;
                    }
                else
                    randomMovement = Random.Range(0, 5);
                break;

            case 2:
                if (h2.GetComponent<SpriteRenderer>().enabled)
                {
                    transform.position += new Vector3(1, 0, 0);
                    nbTurn -= 1;
                        timerTurn = 2f;
                    }
                else
                    randomMovement = Random.Range(0, 5);
                break;

            case 3:
                if (h3.GetComponent<SpriteRenderer>().enabled)
                {
                    transform.position += new Vector3(-1, 0, 0);
                    nbTurn -= 1;
                        timerTurn = 2f;
                    }
                else
                    randomMovement = Random.Range(0, 5);
                break;
        }
    }

}
