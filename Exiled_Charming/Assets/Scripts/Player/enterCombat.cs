using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterCombat : MonoBehaviour
{
    public gameManager gameManager;
    public List<BoxCollider2D> myColliders;
    private bool setPosTp;

    [HideInInspector] public GameObject tpPoint;
    public Vector3 tpPos;

    private void Start()
    {
        tpPos = new Vector3(120, 45, -1);
        tpPoint = GameObject.Find("pointTpAfterFight");
    }
    private void Update()
    {
        if(setPosTp)
        {
            tpPoint.transform.parent = null;

            tpPos = tpPoint.transform.position;

            setPosTp = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ennemi")
        {
            gameManager.state = gameState.Fight;
            setPosTp = true;
        }
    }
}
