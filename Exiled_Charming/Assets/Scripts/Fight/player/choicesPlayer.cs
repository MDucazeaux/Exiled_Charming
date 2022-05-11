using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choicesPlayer : MonoBehaviour
{
    public static choicesPlayer Instance;

    public Button Move;
    public Button Heal;
    public Button Pass;
    public Button Atk1;
    public Button Atk2;

    private bool canMove, canHeal ;

    public bool canAttack;
    public int choice;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        canAttack = true;
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
                        if (Input.GetKeyDown(KeyCode.W))
                        {
                            transform.position += new Vector3(0, 1, 0);
                            Move.gameObject.SetActive(false);
                            Atk1.gameObject.SetActive(true);
                            Atk2.gameObject.SetActive(true);
                            Heal.gameObject.SetActive(true);
                            canMove = false;
                        }
                        else if (Input.GetKeyDown(KeyCode.A))
                        {
                            transform.position -= new Vector3(1, 0, 0);
                            Move.gameObject.SetActive(false);
                            Atk1.gameObject.SetActive(true);
                            Atk2.gameObject.SetActive(true);
                            Heal.gameObject.SetActive(true);
                            canMove = false;
                        }
                        else if (Input.GetKeyDown(KeyCode.S))
                        {
                            transform.position -= new Vector3(0, 1, 0);
                            Move.gameObject.SetActive(false);
                            Atk1.gameObject.SetActive(true);
                            Atk2.gameObject.SetActive(true);
                            Heal.gameObject.SetActive(true);
                            canMove = false;
                        }
                        else if (Input.GetKeyDown(KeyCode.D))
                        {
                            transform.position += new Vector3(1, 0, 0);
                            Move.gameObject.SetActive(false);
                            Atk1.gameObject.SetActive(true);
                            Atk2.gameObject.SetActive(true);
                            Heal.gameObject.SetActive(true);
                            canMove = false;
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
                    fightManager.Instance.updateState(GameState.EnemyTurn);
                    choice = -1;
                    break;
            }
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
}
