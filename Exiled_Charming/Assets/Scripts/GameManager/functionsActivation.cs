using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class functionsActivation : MonoBehaviour
{
    public GameObject managers;
    public GameObject Map;
    private GameObject Player;
    public GameObject Ennemi = null;
    public GameObject fightStructure;
    public Camera camera;

    private gameManager gameManager;
    public Sprite princessModel;

    private GameObject musicManager;


    public GameObject UIButtonsFight;
    public GameObject UIButtonsGame;

    public bool gridSet = false;
    bool setPos = false;

    private int pos = 0;
    public bool hasPlayed = false;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
        gameManager = GameObject.Find("gameManager").GetComponent<gameManager>();
        musicManager = GameObject.Find("musicManager");
    }
    public void fightState()
    {
        if (!hasPlayed)
        { 
            musicManager.GetComponent<MusicManager>().PlayingFight = true; hasPlayed = true; 
        }
        if (!gridSet)
        {
            Ennemi = fightManager.Instance.Ennemi;
            setPos = false;

            Player.transform.position = new Vector3(0, 6, -4);
            camera.transform.parent = null;
            Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            //disable components linked to the player that are useless to him in fight
            Player.GetComponent<enterCombat>().myColliders[0].enabled = false;
            Player.GetComponent<enterCombat>().myColliders[1].enabled = true;
            Player.GetComponent<enterCombat>().myColliders[2].enabled = true;
            Player.GetComponent<Movements>().enabled = false;
            Player.GetComponent<AnimManager>().enabled = false;
            Player.GetComponent<TriggerManager>().enabled = false;
            Player.GetComponent<enterCombat>().enabled = false;
            Player.GetComponent<Animator>().enabled = false;
            Player.GetComponent<SpriteRenderer>().sprite = princessModel;


            //enable components linked to the player that are useful to the player in fight
            Player.GetComponent<XpManager>().enabled = true;
            Player.GetComponent<HpManager>().enabled = true;
            Player.GetComponent<StatsManager>().enabled = true;
            Player.GetComponent<CharacterStats>().enabled = true;
            Player.GetComponent<choicesPlayer>().enabled = true;
            Player.GetComponent<attackType>().enabled = true;
            Player.GetComponent<playermovement>().enabled = true;


            //enable components linked to the enemy that are useful in fight
            Ennemi.GetComponent<HpManager>().SetHealthBar();
            Ennemi.GetComponent<XpManager>().enabled = true;
            Ennemi.GetComponent<StatsManager>().enabled = true;
            Ennemi.GetComponent<enemyUnit>().enabled = true;
            Ennemi.GetComponent<choicesIA>().enabled = true;
            Ennemi.GetComponent<attacksIA>().enabled = true;

            //Ennemi.GetComponent<AIBT>().enabled = false;
            //Ennemi.GetComponent<Animator>().enabled = false;


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
        gameManager.hasSetGrid = 0;

        if(hasPlayed)
        {
            if (musicManager.GetComponent<MusicManager>().PlayingTrip)
            {
                musicManager.GetComponent<AudioSource>().Stop();
                musicManager.GetComponent<MusicManager>().PlayingTrip = true;
                musicManager.GetComponent<MusicManager>().PlayingFight = false;
                musicManager.GetComponent<AudioSource>().PlayOneShot(musicManager.GetComponent<MusicManager>().Mtrip, 0.2f);
                musicManager.GetComponent<MusicManager>().PlayingCastle = false;
                hasPlayed = false;

            }
            else if (musicManager.GetComponent<MusicManager>().PlayingCastle)
            {
                musicManager.GetComponent<AudioSource>().Stop();
                musicManager.GetComponent<MusicManager>().PlayingTrip = false;
                musicManager.GetComponent<MusicManager>().PlayingFight = false;
                musicManager.GetComponent<AudioSource>().PlayOneShot(musicManager.GetComponent<MusicManager>().Mcastle, 0.2f);
                musicManager.GetComponent<MusicManager>().PlayingCastle = true;
                hasPlayed = false;
            }
        }

        if (!setPos)
        { 
            Player.transform.position = Player.GetComponent<enterCombat>().tpPos;
            Player.GetComponent<enterCombat>().tpPoint.transform.parent = Player.transform;
            setPos = true;
        }

        if (Player != null)
        {

            Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            camera.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -5);
            camera.transform.parent = Player.transform;

            Player.GetComponent<enterCombat>().myColliders[0].enabled = true;
            Player.GetComponent<enterCombat>().myColliders[1].enabled = false;
            Player.GetComponent<enterCombat>().myColliders[2].enabled = false;
            Player.GetComponent<Movements>().enabled = true;
            Player.GetComponent<AnimManager>().enabled = true;
            Player.GetComponent<TriggerManager>().enabled = true;
            Player.GetComponent<enterCombat>().enabled = true;
            Player.GetComponentInChildren<AudioListener>().enabled = true;
            Player.GetComponent<Animator>().enabled = true;
            Player.GetComponent<SpriteRenderer>().sprite = null;

            Player.GetComponent<XpManager>().enabled = false;
            Player.GetComponent<HpManager>().enabled = false;
            Player.GetComponent<StatsManager>().enabled = true;
            Player.GetComponent<CharacterStats>().enabled = true;
            Player.GetComponent<choicesPlayer>().enabled = false;
            Player.GetComponent<attackType>().enabled = false;
            Player.GetComponent<playermovement>().enabled = false;
        }

        if (Ennemi != null)
        {
            Ennemi.GetComponent<XpManager>().enabled = false;
            Ennemi.GetComponent<StatsManager>().enabled = false;
            Ennemi.GetComponent<enemyUnit>().enabled = false;
            Ennemi.GetComponent<choicesIA>().enabled = false;
            Ennemi.GetComponent<attacksIA>().enabled = false;
        }

        //Ennemi.GetComponent<AIBT>().enabled = true;
        //Ennemi.GetComponent<Animator>().enabled = true;

        UIButtonsFight.SetActive(false);
        UIButtonsGame.SetActive(true);
        fightStructure.SetActive(false);
        Map.SetActive(true);
        fightManager.Instance.updateState(GameState.waitForStart);
        managers.SetActive(false);
    }
}
