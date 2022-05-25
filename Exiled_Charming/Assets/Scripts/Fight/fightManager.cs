using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fightManager : MonoBehaviour
{
    public static fightManager Instance;
    public GameState state;

    public gridSystem grid;

    public Camera camera;

    public playermovement Player;
    public GameObject Ennemi = null;

    public Image HealthBar;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
    }

    public void updateState(GameState stateAsked)
    {
        state = stateAsked;

        switch (state)
        {
            case GameState.waitForStart://is waiting for a fight to start
                break;

            case GameState.startFight: //permite to load the scene
                Ennemi.transform.localPosition = new Vector3(9, 6, -4);
                if(grid.gridCreated)
                {
                    grid.gridAlreadyCreated();
                }
                else
                {
                    grid.createGrid();
                }

                break;

            case GameState.playerTurn://Player turn so we set everything that touch the player to true and the enemy to false(NEED TO DO SO FOR EVERY ENEMIES IDENTITY TYPE)
                Player.GetComponent<playermovement>().PlayerTurn = true;
                Ennemi.GetComponent<enemyUnit>().EnemyTurn = false;
                break;

            case GameState.EnemyTurn: //Enemy turn so we set everything that touch the player to false and the enemy to true (NEED TO CHECK IDENTITY)
                Ennemi.GetComponent<enemyUnit>().EnemyTurn = true;
                Ennemi.GetComponent<enemyUnit>().makeDecision();
                Player.GetComponent<playermovement>().PlayerTurn = false;
                break;
            case GameState.UpdatePlayer:
                choicesPlayer.Instance.activateButtons();
                updateState(GameState.playerTurn);
                break;
            case GameState.UpdateEnnemi:
                Ennemi.GetComponent<choicesIA>().setVariables();
                updateState(GameState.EnemyTurn);
                break;
        }
    }

}
public enum GameState //all states of the game
    {
        waitForStart,
        startFight,
        playerTurn,
        EnemyTurn,
        UpdatePlayer,
        UpdateEnnemi
    }