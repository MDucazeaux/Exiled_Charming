using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightManager : MonoBehaviour
{
    public static fightManager Instance;
    public GameState state;

    [SerializeField] playermovement Player;
    [SerializeField] posEnnemiField Ennemi;


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
                Ennemi.GetComponent<posEnnemiField>().EnemyTurn = false;
                break;
            case GameState.EnemyTurn:
                Ennemi.GetComponent<posEnnemiField>().EnemyTurn = true;
                Player.GetComponent<playermovement>().PlayerTurn = false;
                break;
        }
    }

    void startFight()
    {
        state = GameState.playerTurn;
    }
}
public enum GameState
    {
        waitForStart,
        startFight,
        playerTurn,
        EnemyTurn
    }