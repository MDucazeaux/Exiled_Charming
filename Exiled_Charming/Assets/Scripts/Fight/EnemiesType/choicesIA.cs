using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choicesIA : MonoBehaviour
{
    [HideInInspector] public static choicesIA Instance;

    [HideInInspector] public GameObject isCollider = null;

    [HideInInspector] public int x;

    [HideInInspector] public int choice = -1;

    [HideInInspector] private int healCapacity;

    public List<GameObject> sensors = new List<GameObject>();

    public int entityType = 0;

    [HideInInspector] public bool canMove = true;

    private float thinkingTimer = 2.0f;

    private void Start()
    {
        switch(entityType)
        {
            case 0: healCapacity = 3; break;
            case 1: healCapacity = 1; break;
            case 2: healCapacity = 0; break;
        }
    }
    private void Update()
    {
        if(this.GetComponent<prince>().EnemyTurn)
        switch(choice)
        {
            case 0:
                    //MOVEMENTS IA
                if (canMove)
                {
                    thinkingTimer -= Time.deltaTime;
                    if(thinkingTimer <= 0)
                    {
                        x = Random.Range(0, 6);
                        switch (x)
                        {
                            case 0:
                                if (sensors[0].GetComponent<deplacementPlayer>().GetComponent<SpriteRenderer>().enabled)
                                {
                                    this.gameObject.transform.position += new Vector3(1, 0, 0);
                                    canMove = false;
                                    thinkingTimer = 2;
                                }
                                else
                                {
                                }
                                break;
                            case 1:
                                if (sensors[1].GetComponent<deplacementPlayer>().GetComponent<SpriteRenderer>().enabled)
                                {
                                    this.gameObject.transform.position += new Vector3(0, 1, 0);
                                    canMove = false;
                                    thinkingTimer = 2;
                                }
                                else
                                {
                                }
                                break;
                            case 2:
                                if (sensors[2].GetComponent<deplacementPlayer>().GetComponent<SpriteRenderer>().enabled)
                                {
                                    this.gameObject.transform.position += new Vector3(0, -1, 0);
                                    canMove = false;
                                    thinkingTimer = 2;
                                }
                                else
                                {
                                }
                                break;
                            case 3:
                                if (sensors[3].GetComponent<deplacementPlayer>().GetComponent<SpriteRenderer>().enabled)
                                {
                                    this.gameObject.transform.position += new Vector3(-1, 0, 0);
                                    canMove = false;
                                    thinkingTimer = 2;
                                }
                                else
                                {
                                }
                                break;
                        }
                    }
                }
                else if (!canMove)
                {
                    choice = Random.Range(1, 5);
                }
                break;
            case 1:
                    //HEALTH IA
                thinkingTimer -= Time.deltaTime;
                if (thinkingTimer <= 0)
                if (healCapacity >0 && this.gameObject.GetComponent<HpManager>().Hp < 60 && !canMove)
                {
                    healCapacity -= 1;
                    this.gameObject.GetComponent<HpManager>().BasedHP += 50;
                    this.gameObject.GetComponent<prince>().enabledTurn = true;
                    fightManager.Instance.updateState(GameState.UpdatePlayer);
                    choice = -1;
                    thinkingTimer = 2;

                }
                else if(healCapacity <= 0 && !canMove || this.gameObject.GetComponent<HpManager>().Hp == this.gameObject.GetComponent<HpManager>().maxHp &&!canMove)
                {
                    this.gameObject.GetComponent<prince>().enabledTurn = true;
                    fightManager.Instance.updateState(GameState.UpdatePlayer);
                    choice = -1;
                }
                else
                {
                     this.gameObject.GetComponent<prince>().enabledTurn = true;
                     fightManager.Instance.updateState(GameState.UpdatePlayer);
                     thinkingTimer = 2;
                     choice = -1;
                }
                break;
            case 2:
                    //ATTACK 1
                thinkingTimer -= Time.deltaTime;
                if (thinkingTimer <= 0)
                if (!canMove)
                {
                    Debug.Log("attk1");

                    this.gameObject.GetComponent<attacksIA>().enableAttack1 = true ;
                    thinkingTimer = 2;
                    choice = -1;
                }
                else
                {
                    thinkingTimer = 2;
                    choice = Random.Range(0, 5);
                }
                break;
            case 3:
                    //ATTACK2
                thinkingTimer -= Time.deltaTime;
                if (thinkingTimer <= 0)
                if (!canMove)
                {
                    Debug.Log("attk2");

                    this.gameObject.GetComponent<attacksIA>().enableAttack2 = true;
                    thinkingTimer = 2;
                    choice = -1;
                }
                else
                {
                    thinkingTimer = 2;
                    choice = Random.Range(0, 5);    
                }
                break;
            case 4:
                    //PASS TURN
                thinkingTimer -= Time.deltaTime;
                if (thinkingTimer <= 0)
                if (canMove)
                {
                    canMove = false;
                    thinkingTimer = 2;
                }
                if(!canMove)
                {
                    this.gameObject.GetComponent<prince>().enabledTurn = false;
                    fightManager.Instance.updateState(GameState.UpdatePlayer);
                    thinkingTimer = 2;
                    choice = -1;
                }
                break;
        }
    }
}
