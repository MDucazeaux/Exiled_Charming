using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posEnnemiField : MonoBehaviour
{
    public bool EnemyTurn;
    private int posX, posY;

    private void Awake()
    {
    }
    void Start()
    {
        //set the enemy at a random position on the grid.
        posX = Random.Range(1, 20);
        posY = Random.Range(1, 10);

        transform.position = new Vector3(posX, posY, -3);
    }

    private void Update()
    {
        //wait for the enemy turn to make action.
        if (fightManager.Instance.state == GameState.EnemyTurn && EnemyTurn)
        {
            //enemy can attack, move

            //switch to false
            //switch to PlayerTurn
        }
    }

    private void PlayerTurn()
    {
        //when the enemy turn has ended, it's the player's turn to play.
        fightManager.Instance.updateState(GameState.playerTurn);
    }

}
