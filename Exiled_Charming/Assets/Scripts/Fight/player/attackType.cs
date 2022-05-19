using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attackType : MonoBehaviour
{
    public static attackType Instance;

    public int def;
    public int typeAttack = -1;
    public Button btnValided;
    public Button btnReturn;

    public bool isValided = false;

    public GameObject tile = null;

    public int atkNb = -1;
    public bool enableAttack1,enableAttack2;

    private void Start()
    {
        def = GameObject.FindGameObjectWithTag("ennemi").GetComponent<StatsManager>().baseDef;
        enableAttack1 = GameObject.FindGameObjectWithTag("nearSlash").GetComponent<detectionHighLight>().GetComponentInChildren<highlight1>().enableAttack;
        enableAttack2 = GameObject.FindGameObjectWithTag("farSlash").GetComponent<detectionHighLight>().GetComponentInChildren<highlight2>().enableAttack;
    }
    public void Update()
    {
        if (tile != null)
        {
            switch (atkNb)
            {
                case 1: enableAttack1 = true; enableAttack2 = false; break;

                case 2: enableAttack2 = true; enableAttack1 = false; break;

                default: atkNb = 0; break;
            }
        }

        if (fightManager.Instance.state == GameState.playerTurn && tile != null)
        switch (typeAttack)
        {
            case 0:
                //player selects a case
                if (enableAttack1)
                {
                    dealDamage1(this.gameObject.GetComponent<CharacterStats>().Damage.GetValue() + 15);
                    fightManager.Instance.updateState(GameState.UpdateEnnemi);
                }
                break;

            case 1:
                //player selects a case
                if (enableAttack2)
                {
                    dealDamage2(this.gameObject.GetComponent<CharacterStats>().Damage.GetValue());
                    fightManager.Instance.updateState(GameState.UpdateEnnemi);
                }
                break;
        }
    }

    private void dealDamage1(int dmg)
    {
        tile.gameObject.GetComponent<HpManager>().BasedHP += def - dmg;
        enableAttack1 = false;
        atkNb = 0;
    }

    private void dealDamage2(int dmg)
    {
        tile.gameObject.GetComponent<HpManager>().BasedHP += def - dmg;
        enableAttack2 = false;
        atkNb = 0;
    }

    public void emptyTile()
    {
        fightManager.Instance.updateState(GameState.UpdateEnnemi);
    }

}
