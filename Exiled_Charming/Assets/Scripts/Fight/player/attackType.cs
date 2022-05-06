using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackType : MonoBehaviour
{
    public int typeAttack = -1;
    public GameObject hTiles;
    public GameObject vTiles;

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
                }
                else
                {
                    hTiles.SetActive(false);
                    vTiles.SetActive(false);
                }
                break;

            case 1:
                if (choicesPlayer.Instance.choice == 3 && fightManager.Instance.state == GameState.playerTurn)
                {
                    hTiles.SetActive(false);
                    vTiles.SetActive(true);
                }
                else
                {
                    hTiles.SetActive(false);
                    vTiles.SetActive(false);
                }
                break;
        }
    }

}
