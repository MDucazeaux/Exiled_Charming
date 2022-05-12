using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightManager : MonoBehaviour
{
    public static fightManager Instance;
    public GameState state;

    public playermovement Player;
    public prince Ennemi;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        updateState(GameState.waitForStart);
    }
    public void updateState(GameState stateAsked)
    {
        state = stateAsked;
    }

    private void Update()
    {
        if(state == GameState.waitForStart)
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                updateState(GameState.startFight);
            }
        }
        switch (state)
        {
            case GameState.waitForStart:
                break;
            case GameState.startFight:
                startFight();
                break;
            case GameState.playerTurn:
                Player.GetComponent<playermovement>().PlayerTurn = true;
                Ennemi.GetComponent<prince>().EnemyTurn = false;
                this.gameObject.GetComponent<updatePlayer>().update = false;
                break;
            case GameState.EnemyTurn:
                Ennemi.GetComponent<prince>().EnemyTurn = true;
                Ennemi.GetComponent<prince>().makeDecision();
                Player.GetComponent<playermovement>().PlayerTurn = false;
                this.gameObject.GetComponent<updatePlayer>().update = false;
                break;
            case GameState.UpdatePlayer:
                this.gameObject.GetComponent<updatePlayer>().updateHero();
                break;
        }
    }

    void startFight()
    {
        int random = Random.Range(0, 2);

        switch(random)
        {
            case 0: updateState(GameState.EnemyTurn); break;
            case 1: updateState(GameState.playerTurn); break;
        }
    }
}
public enum GameState
    {
        waitForStart,
        startFight,
        playerTurn,
        EnemyTurn,
        UpdatePlayer,
        DestroyScene
    }