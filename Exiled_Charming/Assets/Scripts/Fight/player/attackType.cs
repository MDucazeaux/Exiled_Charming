using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attackType : MonoBehaviour
{
    public static attackType Instance;
    public int typeAttack = -1;
    public GameObject hTiles;
    public GameObject vTiles;
    public Button btnValided;
    public Button btnReturn;

    public bool isValided = false;

    public List<GameObject> hSideTiles;

    private void Start()
    {
    }
    public void Update()
    {
        switch(typeAttack)
        {
            case 0:
                if (choicesPlayer.Instance.choice == 2 && fightManager.Instance.state == GameState.playerTurn)
                {
                    hTiles.SetActive(true);
                    vTiles.SetActive(false);

                    btnValided.gameObject.SetActive(true);
                    btnReturn.gameObject.SetActive(true);
                    
                }
                else
                {
                    hTiles.SetActive(false);
                    vTiles.SetActive(false);

                    isValided = false;
                    btnValided.gameObject.SetActive(false);
                    btnReturn.gameObject.SetActive(false);
                }
                break;

            case 1:
                if (choicesPlayer.Instance.choice == 3 && fightManager.Instance.state == GameState.playerTurn)
                {
                    hTiles.SetActive(false);
                    vTiles.SetActive(true);

                    btnValided.gameObject.SetActive(true);
                    btnReturn.gameObject.SetActive(true);
                }
                else
                {
                    hTiles.SetActive(false);
                    vTiles.SetActive(false);

                    isValided = false;
                    btnValided.gameObject.SetActive(false);
                    btnReturn.gameObject.SetActive(false);
                }
                break;
        }
    }

    public void Valid()
    {
        isValided = true;
    }

    public void Return()
    {
        isValided = false;
    }

}
