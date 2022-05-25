using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateEnnemi : MonoBehaviour
{
    private GameObject Ennemi;

    private void Start()
    {
        Ennemi = GameObject.FindGameObjectWithTag("ennemi").GetComponent<choicesIA>().gameObject;
    }
    public void UpdateEnnemi()
    {
        fightManager.Instance.updateState(GameState.EnemyTurn);
        Ennemi.GetComponent<choicesIA>().setVariables();
    }
}
