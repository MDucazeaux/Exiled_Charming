using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updatePlayer : MonoBehaviour
{
    public bool update;

    public GameObject Player;

    private GameObject Move, Heal, Atk1, Atk2, Pass;

    public void updateHero()
    {
        fightManager.Instance.updateState(GameState.playerTurn);
        Player.GetComponent<choicesPlayer>().activateButtons();
    }
}
