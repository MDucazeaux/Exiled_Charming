using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacksIA : MonoBehaviour
{
    public static attackType Instance;

    [HideInInspector] public int def;
    [HideInInspector] public int typeAttack = -1;

    public GameObject colliderEnnemi = null;
    public GameObject colliderPlayer = null;

    [HideInInspector] public bool enableAttack1, enableAttack2;

    private void Start()
    {
        GameObject.Find("Player").GetComponent<CharacterStats>().additionAdDef();
        def = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().amountDef;
    }
    public void Update()
    {
        if(fightManager.Instance.state == GameState.EnemyTurn)
        {

            if (colliderPlayer != null)
            {
                if (enableAttack1)
                {
                    dealDamage1(this.gameObject.GetComponent<StatsManager>().AD + 15);
                    fightManager.Instance.updateState(GameState.UpdatePlayer);
                    this.gameObject.GetComponent<choicesIA>().choice = -1;

                }

                if (enableAttack2)
                {
                    dealDamage2(this.gameObject.GetComponent<StatsManager>().AD);
                    fightManager.Instance.updateState(GameState.UpdatePlayer);
                    this.gameObject.GetComponent<choicesIA>().choice = -1;

                }
            }
            else if (colliderPlayer == null && this.gameObject.GetComponent<choicesIA>().choice == 2 || colliderPlayer == null && this.gameObject.GetComponent<choicesIA>().choice == 3)
            {
                emptyTile();
                this.gameObject.GetComponent<choicesIA>().choice = -1;
            }
        }
    }
    private void dealDamage1(int dmg)
    {
        if(colliderPlayer.GetComponent<CharacterStats>().amountDef - dmg < colliderPlayer.GetComponent<CharacterStats>().CurrentHealth)
            colliderPlayer.gameObject.GetComponent<CharacterStats>().TakeDamage(dmg);
        enableAttack1 = false;
    }

    private void dealDamage2(int dmg)
    {
        if (colliderPlayer.GetComponent<CharacterStats>().amountDef - dmg < colliderPlayer.GetComponent<CharacterStats>().CurrentHealth)
            colliderPlayer.gameObject.GetComponent<CharacterStats>().TakeDamage(dmg);

        enableAttack2 = false;
    }

    private void emptyTile()
    {
        fightManager.Instance.updateState(GameState.UpdatePlayer);
    }

}
