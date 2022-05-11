using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attackType : MonoBehaviour
{
    public static attackType Instance;

    public int typeAttack = -1;
    public Button btnValided;
    public Button btnReturn;

    public bool isValided = false;

    public GameObject tile = null;

    public int atkNb = -1;
    public bool enableAttack1,enableAttack2;

    private void Start()
    {
        enableAttack1 = GameObject.FindGameObjectWithTag("nearSlash").GetComponent<detectionHighLight>().GetComponentInChildren<highlight1>().enableAttack;
        enableAttack1 = GameObject.FindGameObjectWithTag("farSlash").GetComponent<detectionHighLight>().GetComponentInChildren<highlight2>().enableAttack;
    }
    public void Update()
    {
        if(tile != null)
        {
            switch (atkNb)
            {
                case 1: enableAttack1 = true; enableAttack2 = false; break;

                case 2: enableAttack2 = true; enableAttack1 = false; break;

                default: atkNb = 0; break;
            }
        }

        if(fightManager.Instance.state == GameState.playerTurn)
        switch(typeAttack)
        {
            case 0:
                //player need to select a case
                if (enableAttack1)
                {
                        dealDamage1(this.gameObject.GetComponent<StatsManager>().AD + 15);
                        fightManager.Instance.updateState(GameState.EnemyTurn);
                }
                break;

            case 1:
                //player need to select a case
                if (enableAttack2)
                {
                        dealDamage2(this.gameObject.GetComponent<StatsManager>().AD);
                        fightManager.Instance.updateState(GameState.EnemyTurn);
                    }
                break;
        }
    }

    //the player cant attack if he has nothing in range since it would be useless, if he doesnt have to heal, cant move and doesnt have anyone in range he'll need to pass his turn.

    public void Valid()
    {
        isValided = true;
    }

    public void Return()
    {
        isValided = false;
    }

    private void dealDamage1(int dmg)
    {
        Debug.Log("yay dmg1");
        int def = tile.GetComponent<StatsManager>().Def;
        tile.gameObject.GetComponent<HpManager>().totalHp += def - dmg;
        enableAttack1 = false;
        atkNb = 0;
    }

    private void dealDamage2(int dmg)
    {
        Debug.Log("yay dmg2");
        int def = tile.GetComponent<StatsManager>().Def;
        tile.gameObject.GetComponent<HpManager>().totalHp += def - dmg;
        enableAttack2 = false;
        atkNb = 0;
    }

}
