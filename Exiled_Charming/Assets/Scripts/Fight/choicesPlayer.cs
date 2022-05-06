using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choicesPlayer : MonoBehaviour
{
    public static choicesPlayer Instance;
    public playermovement Player;
    public int choice;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
    }

    private void Update()
    {
        if(Player.PlayerTurn)
        switch(choice)
        {
            case 0:
                if(Input.GetKeyDown(KeyCode.W))
                {
                    transform.position += new Vector3(0, 1, 0);
                    fightManager.Instance.updateState(GameState.EnemyTurn);
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    transform.position -= new Vector3(1, 0, 0);
                    fightManager.Instance.updateState(GameState.EnemyTurn);
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    transform.position -= new Vector3(0, 1, 0);
                    fightManager.Instance.updateState(GameState.EnemyTurn);
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    transform.position += new Vector3(1, 0, 0);
                    fightManager.Instance.updateState(GameState.EnemyTurn);
                }
                    break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }
    public void pickMove()
    {
        choice = 0;
    }

    public void pickHeal()
    {
        choice = 1;
    }
    public void pickAttack1()
    {
        choice = 2;
    }
    public void pickAttack2()
    {
        choice = 3;
    }
    
    public void pickPass()
    {
        choice = 4;
    }
}
