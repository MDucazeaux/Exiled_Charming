using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this component will set all the ai variables before its turn so that he can play again
public class updateEnnemi : MonoBehaviour
{
    private GameObject Ennemi;

    private void Start()
    {
    }
    public void UpdateEnnemi()
    {
        if (Ennemi != null)
            Ennemi = GameObject.FindGameObjectWithTag("ennemi").GetComponent<choicesIA>().gameObject;

        fightManager.Instance.updateState(GameState.EnemyTurn);
        Ennemi.GetComponent<choicesIA>().setVariables();
    }
}
