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

    private bool canMove, canHeal;

    [HideInInspector] public int choice;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        canMove  = true;


        Heal.gameObject.SetActive(false);
        Atk1.gameObject.SetActive(false);
        Atk2.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (this.GetComponent<playermovement>().PlayerTurn)
        {

            switch (choice)
            {
                //the player has to move first (one case range).
                case 0:
                    if (canMove)
                    {
                        if (Input.GetKeyDown(KeyCode.W) && possibleMove[0].GetComponent<deplacementPlayer>().GetComponent<SpriteRenderer>().enabled)
                        {
                            transform.position += new Vector3(0, 1, 0);
                            Move.gameObject.SetActive(false);
                            Atk1.gameObject.SetActive(true);
                            Atk2.gameObject.SetActive(true);
                            Heal.gameObject.SetActive(true);
                            canMove = false;
                        }
                        else
                        {
                           
                        }
                        
                        
                        if (Input.GetKeyDown(KeyCode.A) && possibleMove[1].GetComponent<deplacementPlayer>().GetComponent<SpriteRenderer>().enabled)
                        {
                            transform.position -= new Vector3(1, 0, 0);
                            Move.gameObject.SetActive(false);
                            Atk1.gameObject.SetActive(true);
                            Atk2.gameObject.SetActive(true);
                            Heal.gameObject.SetActive(true);
                            canMove = false;
                        }
                        else
                        {
                        }


                        if (Input.GetKeyDown(KeyCode.S) && possibleMove[2].GetComponent<deplacementPlayer>().GetComponent<SpriteRenderer>().enabled)
                        {
                            transform.position -= new Vector3(0, 1, 0);
                            Move.gameObject.SetActive(false);
                            Atk1.gameObject.SetActive(true);
                            Atk2.gameObject.SetActive(true);
                            Heal.gameObject.SetActive(true);
                            canMove = false;
                        }
                        else
                        {
                        }


                        if (Input.GetKeyDown(KeyCode.D) && possibleMove[3].GetComponent<deplacementPlayer>().GetComponent<SpriteRenderer>().enabled)
                        {
                            transform.position += new Vector3(1, 0, 0);
                            Move.gameObject.SetActive(false);
                            Atk1.gameObject.SetActive(true);
                            Atk2.gameObject.SetActive(true);
                            Heal.gameObject.SetActive(true);
                            canMove = false;
                        }
                        else
                        {
                        }
                    }
                    break;

                //once the player moved he has many choices : 


                //he can heal.
                case 1:
                    if (!canMove)
                    {
                        transform.GetComponent<HpManager>().heal += 50;
                        fightManager.Instance.updateState(GameState.EnemyTurn);
                        choice = -1;
                    }
                    break;

                //he can do the first type of attack (crit).
                case 2:
                    if (!canMove)
                    {
                        transform.GetComponent<attackType>().typeAttack = 0;
                    }
                    break;

                //he can do the second type of attack(no crit).
                case 3:
                    if (!canMove)
                    {
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
                        fightManager.Instance.updateState(GameState.EnemyTurn);
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
