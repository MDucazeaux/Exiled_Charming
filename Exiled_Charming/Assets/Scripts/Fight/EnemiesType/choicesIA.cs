using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choicesIA : MonoBehaviour
{
    [HideInInspector] public static choicesIA Instance;

    [HideInInspector] public int choice = -1;

    public int healCapacity;


    public List<GameObject> sensors = new List<GameObject>();
    public GameObject sensorSupport;


    public int entityType = 0;

    public bool canMove = true;

    public float thinkingTimer = 2.0f;

    private Vector2 posPlayer;

    private void Start()
    {
        switch(entityType)
        {
            case 0: healCapacity = 3; break;
            case 1: healCapacity = 1; break;
            case 2: healCapacity = 0; break;
        }

        posPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<playermovement>().transform.position;

        sensorSupport.SetActive(false);
        
    }
    private void Update()
    {
        if(GameObject.Find("Player") != null)
        posPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<playermovement>().transform.position;

        if (this.GetComponent<prince>().EnemyTurn)
        {
            switch (choice)
            {
                case 0:
                    if (canMove)
                    {
                        sensorSupport.SetActive(true);

                        thinkingTimer -= Time.deltaTime;
                        if (thinkingTimer <= 0)
                        {
                            if (sensors[0].GetComponent<deplacementPlayer>().GetComponent<SpriteRenderer>().enabled && this.gameObject.transform.position.x < posPlayer.x - 1)
                            {
                                this.transform.position += new Vector3(1, 0, 0);
                                sensorSupport.SetActive(false);
                                thinkingTimer = 2;
                                choice = Random.Range(1, 5);
                                canMove = false;
                            }
                            else if (sensors[1].GetComponent<deplacementPlayer>().GetComponent<SpriteRenderer>().enabled && this.gameObject.transform.position.x > posPlayer.x + 1)
                            {
                                this.transform.position -= new Vector3(1, 0, 0);
                                sensorSupport.SetActive(false);
                                thinkingTimer = 2;
                                choice = 1;
                                canMove = false;
                            }
                            else if (sensors[2].GetComponent<deplacementPlayer>().GetComponent<SpriteRenderer>().enabled && this.gameObject.transform.position.y < posPlayer.y - 1)
                            {
                                this.transform.position += new Vector3(0, 1, 0);
                                sensorSupport.SetActive(false);
                                thinkingTimer = 2;
                                choice = Random.Range(1, 5);
                                canMove = false;
                            }
                            else if (sensors[3].GetComponent<deplacementPlayer>().GetComponent<SpriteRenderer>().enabled && this.gameObject.transform.position.y > posPlayer.y + 1)
                            {
                                this.transform.position -= new Vector3(0, 1, 0);
                                sensorSupport.SetActive(false);
                                thinkingTimer = 2;
                                choice = Random.Range(1, 5);
                                canMove = false;
                            }
                            else
                            {
                                sensorSupport.SetActive(false);
                                thinkingTimer = 2;
                                choice = Random.Range(1, 5);
                                canMove = false;
                            }
                        }
                    }
                    break;
                case 1:
                    //HEALTH IA
                    thinkingTimer -= Time.deltaTime;
                    if (thinkingTimer <= 0)
                    {
                        if (this.gameObject.GetComponent<HpManager>().Hp < 60 && healCapacity > 0 && !canMove)
                        {
                            choice = -1;
                            this.gameObject.GetComponent<HpManager>().healAmount();
                            healCapacity -= 1;
                            fightManager.Instance.updateState(GameState.UpdatePlayer);
                            thinkingTimer = 2;
                        }
                        else
                        {
                            choice = Random.Range(2, 5);
                            thinkingTimer = 2;
                        }
                    }
                    break;
                case 2:
                    //ATTACK 1
                    thinkingTimer -= Time.deltaTime;
                    if (thinkingTimer <= 0)
                        if (!canMove)
                        {
                            this.gameObject.GetComponent<attacksIA>().enableAttack1 = true;
                            thinkingTimer = 2;
                        }
                    break;
                case 3:
                    //ATTACK2
                    thinkingTimer -= Time.deltaTime;
                    if (thinkingTimer <= 0)
                    {
                        if (!canMove)
                        {
                            this.gameObject.GetComponent<attacksIA>().enableAttack2 = true;
                            thinkingTimer = 2;
                        }
                    }
                    break;
                case 4:
                    //PASS TURN
                    thinkingTimer -= Time.deltaTime;
                    if (thinkingTimer <= 0)
                    {
                        if (canMove)
                        {
                            canMove = false;
                            thinkingTimer = 2;
                        }
                        if (!canMove)
                        {
                            this.gameObject.GetComponent<prince>().enabledTurn = false;
                            fightManager.Instance.updateState(GameState.UpdatePlayer);
                            thinkingTimer = 2;
                            choice = -1;
                        }
                    }
                    break;
            }
        }
    }

    public void setVariables()
    {
        this.gameObject.GetComponent<attacksIA>().colliderPlayer = null;
        sensorSupport.SetActive(true);
        canMove = true;
    }
}
