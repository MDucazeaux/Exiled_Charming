using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;
    public functionsActivation functionsStates;
    public gameState state;
    public void updateState(gameState newState) //can be called if a change of state is needed (ex: Game->Fight || Fight -> Game)
    {
        state = newState;
    }

    private void Start()
    {
        state = gameState.sceneMenu; //define original state
    }

    private void Update()
    {
        switch(state)
        {
            case gameState.sceneMenu:
                //charger la scene de menu
                break;
            case gameState.sceneGames:
                //charger la scene des parties save (si une partie a deja ete save ou non)
                break;
            case gameState.loadGame:
                //load la partie s'il y en a une
                break;
            case gameState.startGame:
                //recommencer la partie s'il n'y en a pas
                break;
            case gameState.Game:
                functionsStates.gameState();
                break;
            case gameState.Fight:
                functionsStates.fightState();
                break;
            case gameState.Video:
                //joueur ne joue pas mais assiste aux cinématiques
                break;
            case gameState.sceneEnd:
                //crédits
                break;
        }
    }
}

public enum gameState //differents states of the game (can add more)
{
    sceneMenu,
    sceneGames,
    loadGame,
    startGame,
    Game,
    Fight,
    Video,
    sceneEnd
}
