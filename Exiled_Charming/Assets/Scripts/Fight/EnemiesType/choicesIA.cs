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
                if (canMove)
                {
                    x = Random.Range(0, 6);
                    switch (x)
                    {
                        case 0:
                                if (sensors[0].GetComponent<deplacementPlayer>().GetComponent<SpriteRenderer>().enabled)
                                {
                                    this.gameObject.transform.position += new Vector3(1, 0, 0);
                                    canMove = false;
                                }
                                else
                                {
                                    Debug.Log("no space for me here :(");
                                }
                                break;
                        case 1:
                                if (sensors[1].GetComponent<deplacementPlayer>().GetComponent<SpriteRenderer>().enabled)
                                {
                                    this.gameObject.transform.position += new Vector3(0, 1, 0);
                                    canMove = false;
                                }
                                else
                                {
                                    Debug.Log("no space for me here :(");
                                }
                                break;
                        case 2:
                                if (sensors[2].GetComponent<deplacementPlayer>().GetComponent<SpriteRenderer>().enabled)
                                {
                                    this.gameObject.transform.position += new Vector3(0, -1, 0);
                                    canMove = false;
                                }
                                else
                                {
                                    Debug.Log("no space for me here :(");
                                }
                                break;
                        case 3:
                                if (sensors[3].GetComponent<deplacementPlayer>().GetComponent<SpriteRenderer>().enabled)
                                {
                                    this.gameObject.transform.position += new Vector3(-1, 0, 0);
                                    canMove = false;
                                }
                                else
                                {
                                    Debug.Log("no space for me here :(");
                                }
                                break;
                    }
                }
                else if (!canMove)
                {
                    choice = Random.Range(1, 5);
                }
                break;
            case 1:
                if(healCapacity >0 && this.gameObject.GetComponent<HpManager>().Hp < 60 && !canMove)
                {
                    Debug.Log("feeling good to heal a lot :D");
                    healCapacity -= 1;
                    this.gameObject.GetComponent<HpManager>().BasedHP += 50;
                    this.gameObject.GetComponent<prince>().enabledTurn = true;
                    fightManager.Instance.updateState(GameState.UpdatePlayer);
                    choice = -1;

                }
                else if(healCapacity <= 0 && !canMove || this.gameObject.GetComponent<HpManager>().Hp == this.gameObject.GetComponent<HpManager>().maxHp &&!canMove)
                {
                    Debug.Log("the ia doesnt have any heal or she doesnt need it, she lost one round...");
                        this.gameObject.GetComponent<prince>().enabledTurn = true;
                        fightManager.Instance.updateState(GameState.UpdatePlayer);
                    choice = -1;
                }
                else
                {
                        Debug.Log("another reason to lose a round...");
                        this.gameObject.GetComponent<prince>().enabledTurn = true;
                        fightManager.Instance.updateState(GameState.UpdatePlayer);
                        choice = -1;
                    }
                break;
            case 2:
                if(!canMove)
                {
                    Debug.Log("IA Attack1");
                    fightManager.Instance.updateState(GameState.UpdatePlayer);
                        this.gameObject.GetComponent<prince>().enabledTurn = true;
                        choice = -1;
                }
                else
                {
                    Debug.Log("didnt pick a tile to move on...");
                        this.gameObject.GetComponent<prince>().enabledTurn = true;
                        choice = Random.Range(0, 5);
                }
                break;
            case 3:
                if (!canMove)
                {
                    Debug.Log("IA Attack2");
                    fightManager.Instance.updateState(GameState.UpdatePlayer);
                        this.gameObject.GetComponent<prince>().enabledTurn = true;
                        choice = -1;
                }
                else
                {
                        Debug.Log("didnt pick a tile to move on...");
                        this.gameObject.GetComponent<prince>().enabledTurn = true;
                        choice = Random.Range(0, 5);
                }
                break;
            case 4:
                if(canMove)
                {
                    canMove = false;
                        this.gameObject.GetComponent<prince>().enabledTurn = true;
                    }
                if(!canMove)
                {
                        Debug.Log("i'll pass on this round (:");
                        this.gameObject.GetComponent<prince>().enabledTurn = true;
                        fightManager.Instance.updateState(GameState.UpdatePlayer);
                    choice = -1;
                }
                break;
        }
    }
}
