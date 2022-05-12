using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choicesIA : MonoBehaviour
{
    public static choicesIA Instance;

    public int x;

    public int choice = -1;

    private int healCapacity;

    public int entityType = 0;

    private bool canMove = true;

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
        if(this.GetComponent<posEnnemiField>().EnemyTurn)
        switch(choice)
        {
            case 0:
                if (canMove)
                {
                    x = Random.Range(0, 6);
                    switch (x)
                    {
                        case 0: this.gameObject.transform.position += new Vector3(1, 0, 0); canMove = false; break;
                        case 1: this.gameObject.transform.position += new Vector3(0, 1, 0); canMove = false; break;
                        case 2: this.gameObject.transform.position += new Vector3(0, -1, 0); canMove = false; break;
                        case 3: this.gameObject.transform.position += new Vector3(-1, 0, 0); canMove = false; break;
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
                    this.gameObject.GetComponent<HpManager>().Hp += 50;
                    fightManager.Instance.updateState(GameState.UpdatePlayer);
                    choice = -1;

                }
                else if(healCapacity == 0 && !canMove || this.gameObject.GetComponent<HpManager>().Hp == this.gameObject.GetComponent<HpManager>().maxHp &&!canMove)
                {
                    Debug.Log("the ia doesnt have any heal or she doesnt need it, she lost one round...");
                    fightManager.Instance.updateState(GameState.UpdatePlayer);
                    choice = -1;
                }
                break;
            case 2:
                if(!canMove)
                {
                    Debug.Log("IA Attack1");
                    fightManager.Instance.updateState(GameState.UpdatePlayer);
                    choice = -1;
                }
                else
                {
                    Debug.Log("didnt pick a tile to move on...");
                    choice = Random.Range(0, 5);
                }
                break;
            case 3:
                if (!canMove)
                {
                    Debug.Log("IA Attack2");
                    fightManager.Instance.updateState(GameState.UpdatePlayer);
                    choice = -1;
                }
                else
                {
                        Debug.Log("didnt pick a tile to move on...");
                        choice = Random.Range(0, 5);
                }
                break;
            case 4:
                if(canMove)
                {
                    canMove = false;
                }
                if(!canMove)
                {
                        Debug.Log("i'll pass on this round (:");
                    fightManager.Instance.updateState(GameState.UpdatePlayer);
                    choice = -1;
                }
                break;
        }
    }
}
