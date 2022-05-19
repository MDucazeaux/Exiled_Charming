using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this component will make sure that every buttons and settings are set for the player to be able to play in case the fight manager doesnt activate something that is needed.
public class updatePlayer : MonoBehaviour
{
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<choicesPlayer>().gameObject;
    }
    public void updateHero()
    {
        fightManager.Instance.updateState(GameState.playerTurn);
        Player.GetComponent<choicesPlayer>().activateButtons();
        Player.GetComponent<choicesPlayer>().choice = 0;
    }
}
