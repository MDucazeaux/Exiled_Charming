using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightManager : MonoBehaviour
{
    public static fightManager Instance;
    public GameState state;

    public gridSystem grid;

    public Camera camera;

    public playermovement Player;
    public prince Ennemi;

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
                grid.clearDictionary();
                break;

            case GameState.startFight: //permite to load the scene
                Player.transform.position = new Vector3(0, 6, -4);
                Ennemi.transform.localPosition = new Vector3(9, 6, -4);
                grid.createGrid();
                break;

            case GameState.playerTurn://Player turn so we set everything that touch the player to true and the enemy to false(NEED TO DO SO FOR EVERY ENEMIES IDENTITY TYPE)
                Player.GetComponent<playermovement>().PlayerTurn = true;
                Ennemi.GetComponent<prince>().EnemyTurn = false;
                break;

            case GameState.EnemyTurn: //Enemy turn so we set everything that touch the player to false and the enemy to true (NEED TO CHECK IDENTITY)
                Ennemi.GetComponent<prince>().EnemyTurn = true;
                Ennemi.GetComponent<prince>().makeDecision();
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

    public void startFight() //the first one to start is random since it would be too easy to let the player start everytime
    {
        //int random = Random.Range(0, 2);

        //switch(random)
        //{
        //    case 0: updateState(GameState.EnemyTurn); ; break;
        //    case 1: updateState(GameState.playerTurn); break;
        //}
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