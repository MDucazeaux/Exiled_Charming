using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class functionsActivation : MonoBehaviour
{
    public GameObject managers;
    public GameObject Map;
    private GameObject Player;
    public GameObject Ennemi;
    public GameObject fightStructure;

    bool gridSet = false;

    private int pos = 0;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }
    public void fightState()
    {
        if (!gridSet)
        {//disable every game components that belongs to the player
            Player.GetComponent<enterCombat>().myColliders[0].enabled = false;
            Player.GetComponent<enterCombat>().myColliders[1].enabled = true;
            Player.GetComponent<enterCombat>().myColliders[2].enabled = true;
            Player.GetComponent<Movements>().enabled = false;
            Player.GetComponent<AnimManager>().enabled = false;
            Player.GetComponent<TriggerManager>().enabled = false;
            Player.GetComponent<enterCombat>().enabled = false;

            Player.GetComponent<XpManager>().enabled = true;
            Player.GetComponent<HpManager>().enabled = true;
            Player.GetComponent<StatsManager>().enabled = true;
            Player.GetComponent<CharacterStats>().enabled = true;
            Player.GetComponent<choicesPlayer>().enabled = true;
            Player.GetComponent<attackType>().enabled = true;
            Player.GetComponent<playermovement>().enabled = true;

            if (pos == 0)
            {
                Player.transform.position = new Vector3(0, 6, -4);
                Ennemi.transform.position = new Vector3(9, 6, -4);
                pos = 1;
            }


            Ennemi.GetComponent<XpManager>().enabled = true;
            Ennemi.GetComponent<HpManager>().enabled = true;
            Ennemi.GetComponent<StatsManager>().enabled = true;
            Ennemi.GetComponent<prince>().enabled = true;
            Ennemi.GetComponent<choicesIA>().enabled = true;
            Ennemi.GetComponent<attacksIA>().enabled = true;

            fightStructure.SetActive(true);
            Map.SetActive(false);
            managers.SetActive(true);
            fightManager.Instance.updateState(GameState.startFight);
            fightManager.Instance.updateState(GameState.playerTurn);
            gridSet = true;
        }

    }

    public void gameState()
    {
        Player.GetComponent<enterCombat>().myColliders[0].enabled = true;
        Player.GetComponent<enterCombat>().myColliders[1].enabled = false;
        Player.GetComponent<enterCombat>().myColliders[2].enabled = false;
        Player.GetComponent<Movements>().enabled = true;
        Player.GetComponent<AnimManager>().enabled = true;
        Player.GetComponent<TriggerManager>().enabled = true;
        Player.GetComponent<enterCombat>().enabled = true;
        Player.GetComponentInChildren<AudioListener>().enabled = true;


        Ennemi.GetComponent<XpManager>().enabled = false;
        Ennemi.GetComponent<HpManager>().enabled = false;
        Ennemi.GetComponent<StatsManager>().enabled = false;
        Ennemi.GetComponent<prince>().enabled = false;
        Ennemi.GetComponent<choicesIA>().enabled = false;
        Ennemi.GetComponent<attacksIA>().enabled = false;

        fightStructure.SetActive(false);
        Map.SetActive(true);
        fightManager.Instance.updateState(GameState.waitForStart);
        managers.SetActive(false);
    }
}
