using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//differents states of the game(actually 2)
public class gameManager : MonoBehaviour
{
    public static gameManager Instance;
    public functionsActivation functionsStates;
    public gameState state;

    public int hasSetGrid = 0;
    public void updateState(gameState newState) //can be called if a change of state is needed (ex: Game->Fight || Fight -> Game)
    {
        state = newState;
    }

    private void Start()
    {
        state = gameState.Game; //define original state
    }

    private void Update()
    {
        switch(state)
        {
            case gameState.Game:
                functionsStates.gameState();
                break;
            case gameState.Fight:
                if (hasSetGrid == 0)
                { 
                    functionsStates.fightState();
                    functionsStates.gridSet = false;
                    hasSetGrid = 1;
                }
                break;
        }
    }
}

public enum gameState //differents states of the game (can add more)
{
    Game,
    Fight
}
