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


    public GameObject UIButtonsFight;
    public GameObject UIButtonsGame;

    bool gridSet = false;

    private int pos = 0;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }
    public void fightState()
    {
        if (!gridSet)
        {
            //disable components linked to the player that are useless to him in fight
            Player.GetComponent<enterCombat>().myColliders[0].enabled = false;
            Player.GetComponent<enterCombat>().myColliders[1].enabled = true;
            Player.GetComponent<enterCombat>().myColliders[2].enabled = true;
            Player.GetComponent<Movements>().enabled = false;
            Player.GetComponent<AnimManager>().enabled = false;
            Player.GetComponent<TriggerManager>().enabled = false;
            Player.GetComponent<enterCombat>().enabled = false;


            //enable components linked to the player that are useful to the player in fight
            Player.GetComponent<XpManager>().enabled = true;
            Player.GetComponent<HpManager>().enabled = true;
            Player.GetComponent<StatsManager>().enabled = true;
            Player.GetComponent<CharacterStats>().enabled = true;
            Player.GetComponent<choicesPlayer>().enabled = true;
            Player.GetComponent<attackType>().enabled = true;
            Player.GetComponent<playermovement>().enabled = true;


            //enable components linked to the enemy that are useful in fight
            Ennemi.GetComponent<XpManager>().enabled = true;
            Ennemi.GetComponent<HpManager>().enabled = true;
            Ennemi.GetComponent<StatsManager>().enabled = true;
            Ennemi.GetComponent<prince>().enabled = true;
            Ennemi.GetComponent<choicesIA>().enabled = true;
            Ennemi.GetComponent<attacksIA>().enabled = true;


            //manage everything linked to the scene (gestion)
            UIButtonsFight.SetActive(true);
            UIButtonsGame.SetActive(false);
            fightStructure.SetActive(true);
            Map.SetActive(false);
            managers.SetActive(true);
            fightManager.Instance.updateState(GameState.startFight);
            fightManager.Instance.updateState(GameState.UpdatePlayer);
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

        Player.GetComponent<XpManager>().enabled = false;
        Player.GetComponent<HpManager>().enabled = false;
        Player.GetComponent<StatsManager>().enabled = false;
        Player.GetComponent<CharacterStats>().enabled = false;
        Player.GetComponent<choicesPlayer>().enabled = false;
        Player.GetComponent<attackType>().enabled = false;
        Player.GetComponent<playermovement>().enabled = false;


        Ennemi.GetComponent<XpManager>().enabled = false;
        Ennemi.GetComponent<HpManager>().enabled = false;
        Ennemi.GetComponent<StatsManager>().enabled = false;
        Ennemi.GetComponent<prince>().enabled = false;
        Ennemi.GetComponent<choicesIA>().enabled = false;
        Ennemi.GetComponent<attacksIA>().enabled = false;

        UIButtonsFight.SetActive(false);
        UIButtonsGame.SetActive(true);
        fightStructure.SetActive(false);
        Map.SetActive(true);
        fightManager.Instance.updateState(GameState.waitForStart);
        managers.SetActive(false);
    }
}
