using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choicesPlayer : MonoBehaviour
{
    [HideInInspector] public static choicesPlayer Instance;

    public List<GameObject> possibleMove = new List<GameObject>();

    public Button Move;
    public Button Heal;
    public Button Pass;
    public Button Atk1;
    public Button Atk2;

    public bool canMove;

    [HideInInspector] public int choice;

    public GameObject deplacementsPlayer = null;

    private playermovement Player;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<playermovement>();

        canMove  = true;

        deplacementsPlayer.SetActive(false);


        Heal.gameObject.SetActive(false);
        Atk1.gameObject.SetActive(false);
        Atk2.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (this.GetComponent<playermovement>().PlayerTurn)
        {
            if(choice != 0)
            {
                deplacementsPlayer.SetActive(false);
            }

            switch (choice)
            {
                case -1:
                    Player.selectChoice();
                    break;
                //the player has to move first (one case range).
                case 0:
                    if (canMove)
                    {
                        Player.showMovementAllowed(deplacementsPlayer);
                        Player.selectChoice();

                        if (deplacementsPlayer.activeSelf)
                        {
                            if (Input.GetKeyDown(KeyCode.W) && possibleMove[0].GetComponent<deplacementPlayer>().GetComponent<SpriteRenderer>().enabled || Input.GetAxis("joystick right y") < 0 && possibleMove[0].GetComponent<deplacementPlayer>().GetComponent<SpriteRenderer>().enabled)
                            {
                                Player.makeMovement(new Vector3(0, 1, 0));
                            }
                            else if (Input.GetKeyDown(KeyCode.A) && possibleMove[1].GetComponent<deplacementPlayer>().GetComponent<SpriteRenderer>().enabled || Input.GetAxis("joystick right x") < 0 && possibleMove[1].GetComponent<deplacementPlayer>().GetComponent<SpriteRenderer>().enabled)
                            {
                                Player.makeMovement(new Vector3(-1, 0, 0));
                            }
                            else if (Input.GetKeyDown(KeyCode.S) && possibleMove[2].GetComponent<deplacementPlayer>().GetComponent<SpriteRenderer>().enabled || Input.GetAxis("joystick right y") > 0 && possibleMove[2].GetComponent<deplacementPlayer>().GetComponent<SpriteRenderer>().enabled)
                            {
                                Player.makeMovement(new Vector3(0, -1, 0));
                            }
                            else if (Input.GetKeyDown(KeyCode.D) && possibleMove[3].GetComponent<deplacementPlayer>().GetComponent<SpriteRenderer>().enabled || Input.GetAxis("joystick right x") > 0 && possibleMove[3].GetComponent<deplacementPlayer>().GetComponent<SpriteRenderer>().enabled)
                            {
                                Player.makeMovement(new Vector3(1, 0, 0));
                            }
                        }
                    }
                    else
                    {
                        deplacementsPlayer.SetActive(false);
                    }
                    break;

                //once the player moved he has many choices : 


                //he can heal.
                case 1:
                    if (!canMove)
                    {
                        Player.selectChoice();
                        transform.GetComponent<CharacterStats>().CurrentHealth += 50;
                        CharacterStats.Instance.HealthBarImage.fillAmount = this.gameObject.GetComponent<CharacterStats>().CurrentHealth / this.gameObject.GetComponent<CharacterStats>().MaxHealth;
                        CharacterStats.Instance.healthText.text = this.gameObject.GetComponent<CharacterStats>().CurrentHealth + " / " + this.gameObject.GetComponent<CharacterStats>().MaxHealth;

                        fightManager.Instance.updateState(GameState.UpdateEnnemi);
                        choice = -1;
                    }
                    break;

                //he can do the first type of attack (crit).
                case 2:
                    if (!canMove)
                    {
                        Player.selectChoice();
                        transform.GetComponent<attackType>().typeAttack = 0;
                    }
                    break;

                //he can do the second type of attack(no crit).
                case 3:
                    if (!canMove)
                    {
                        Player.selectChoice();
                        transform.GetComponent<attackType>().typeAttack = 1;
                    }
                    break;

                //he can also pass if he doesnt want to do anything.
                case 4:
                    if(canMove)
                    {
                        canMove = false;

                        Move.gameObject.SetActive(false);
                        Atk1.gameObject.SetActive(true);
                        Atk2.gameObject.SetActive(true);
                        Heal.gameObject.SetActive(true);

                        choice = -1;
                    }
                    else if (!canMove)
                    {
                        fightManager.Instance.updateState(GameState.UpdateEnnemi);
                        choice = -1;
                    }
                    break;
            }
        }
        else if(fightManager.Instance.state == GameState.EnemyTurn)
        {
            Move.gameObject.SetActive(false);
            Atk1.gameObject.SetActive(false);
            Atk2.gameObject.SetActive(false);
            Heal.gameObject.SetActive(false);
            Pass.gameObject.SetActive(false);
        }
    }
    public void pickMove()
    {
        deplacementsPlayer.SetActive(true);
        choice = 0;
    }

    public void pickHeal()
    {
        choice = 1;
    }
    public void pickAttack1()
    {
        choice = 2;
    }
    public void pickAttack2()
    {
        choice = 3;
    }
    
    public void pickPass()
    {
        choice = 4;
    }

    public void activateButtons()
    {
        Move.gameObject.SetActive(true);
        Atk1.gameObject.SetActive(true);
        Atk2.gameObject.SetActive(true);
        Heal.gameObject.SetActive(true);
        Pass.gameObject.SetActive(true);

        this.gameObject.GetComponent<attackType>().tile = null;
        deplacementsPlayer.GetComponentInChildren<SpriteRenderer>().enabled = true;
        canMove = true;
        choice = -1;

        setButtons();
    }

    private void setButtons()
    {
        Move.gameObject.SetActive(true);
        Atk1.gameObject.SetActive(false);
        Atk2.gameObject.SetActive(false);
        Heal.gameObject.SetActive(false);
        Pass.gameObject.SetActive(true);
    }
}
