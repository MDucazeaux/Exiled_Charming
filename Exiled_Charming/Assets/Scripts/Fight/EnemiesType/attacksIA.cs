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
        def = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().Armor.GetValue();
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
                    fightManager.Instance.updateState(GameState.playerTurn);
                    this.gameObject.GetComponent<choicesIA>().choice = -1;

                    //verify game object identity (wolf, prince, guard ?)
                    //-> set boolean of the game object personal script to false since its not his turn anymore

                }

                if (enableAttack2)
                {
                    dealDamage2(this.gameObject.GetComponent<StatsManager>().AD);
                    fightManager.Instance.updateState(GameState.playerTurn);
                    this.gameObject.GetComponent<choicesIA>().choice = -1;
                    //deal damage to player (no crit)

                    //update fight manager to updatePlayer

                    //verify game object identity (wolf, prince, guard ?)
                    //-> set boolean of the game object personal script to false since its not his turn anymore

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
        colliderPlayer.gameObject.GetComponent<CharacterStats>().CurrentHealth += def - dmg;
        enableAttack1 = false;
    }

    private void dealDamage2(int dmg)
    {
        colliderPlayer.gameObject.GetComponent<CharacterStats>().CurrentHealth += def - dmg;

        //get healthbar via function in characterStats
        enableAttack2 = false;
    }

    private void emptyTile()
    {
        fightManager.Instance.updateState(GameState.playerTurn);
    }

}
