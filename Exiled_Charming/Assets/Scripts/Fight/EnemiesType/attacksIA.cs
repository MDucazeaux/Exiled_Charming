using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacksIA : MonoBehaviour
{
    public static attackType Instance;

    [HideInInspector] public int def;
    [HideInInspector] public int typeAttack = -1;

    public GameObject colliderPlayer = null;

    [HideInInspector] public bool enableAttack1, enableAttack2;

    private void Start()
    {
        def = GameObject.FindGameObjectWithTag("Player").GetComponent<StatsManager>().baseDef;
    }
    public void Update()
    {
        if(colliderPlayer != null && fightManager.Instance.state == GameState.EnemyTurn)
        {
            if(enableAttack1)
            {
                dealDamage1(this.gameObject.GetComponent<StatsManager>().AD + 15);
                fightManager.Instance.updateState(GameState.UpdatePlayer);

                //verify game object identity (wolf, prince, guard ?)
                //-> set boolean of the game object personal script to false since its not his turn anymore

            }

            if (enableAttack2)
            {
                dealDamage2(this.gameObject.GetComponent<StatsManager>().AD);
                fightManager.Instance.updateState(GameState.UpdatePlayer);
                //deal damage to player (no crit)

                //update fight manager to updatePlayer

                //verify game object identity (wolf, prince, guard ?)
                //-> set boolean of the game object personal script to false since its not his turn anymore

            }
        }
    }
    private void dealDamage1(int dmg)
    {
        colliderPlayer.gameObject.GetComponent<HpManager>().BasedHP += def - dmg;
        enableAttack1 = false;
    }

    private void dealDamage2(int dmg)
    {
        colliderPlayer.gameObject.GetComponent<HpManager>().BasedHP += def - dmg;
        enableAttack2 = false;
    }

    public void emptyTile()
    {
        Debug.Log("IA MISSED TURN");
        fightManager.Instance.updateState(GameState.UpdatePlayer); //enemy doesnt find anyone after chosing so he will just pass this round
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("yes collision");
            colliderPlayer = collision.gameObject;
        }
    }

}
