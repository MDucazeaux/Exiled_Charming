using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attackType : MonoBehaviour
{
    public static attackType Instance;

    public detectionHighLight highLights;
    public int typeAttack = -1;
    public Button btnValided;
    public Button btnReturn;

    public bool isValided = false;

    public GameObject tile = null;

    public int nbChoice = -1;
    public bool enableAttack;

    private void Start()
    {
        nbChoice = choicesPlayer.Instance.choice;
        enableAttack = GameObject.FindGameObjectWithTag("nearSlash").GetComponent<detectionHighLight>().GetComponentInChildren<triggerHighLights>().enableAttack;
    }
    public void Update()
    {
        if(tile != null)
        {
            enableAttack = true;
        }

        switch(typeAttack)
        {
            case 0:
                //player need to pick atk1                it needs to be the player's turn                        the highlight concerned need to be enabled;
                if (enableAttack)
                {
                    btnValided.gameObject.SetActive(true);
                    btnReturn.gameObject.SetActive(true);
                    Debug.Log("coucou");

                }
                break;

            case 1:
                //player need to pick atk2                it needs to be the player's turn                        the highlight concerned need to be enabled;
                if (enableAttack)
                {
                    btnValided.gameObject.SetActive(true);
                    btnReturn.gameObject.SetActive(true);
                }
                break;
        }
    }

    //the player cant attack if he has nothing in range since it would be useless, if he doesnt have to heal, cant move and doesnt have anyone in range he'll need to pass his turn.

    public void Valid()
    {
        isValided = true;
    }

    public void Return()
    {
        isValided = false;
    }

}
