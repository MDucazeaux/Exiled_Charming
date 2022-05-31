using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//permite the player to enter in fight with an enemy

public class enterCombat : MonoBehaviour
{
    public gameManager gameManager;
    public List<BoxCollider2D> myColliders;
    public bool setPosTp = false;

    [HideInInspector] public GameObject tpPoint;
    public Vector3 tpPos;

    private void Start()
    {
        tpPos = new Vector3(4, 5, this.transform.position.z);
        transform.position = tpPos;
        tpPoint = GameObject.Find("pointTpAfterFight");
    }
    private void Update()
    {
        if(setPosTp)
        {
            tpPos = transform.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ennemi" || collision.gameObject.tag =="rat")
        {
            gameManager.state = gameState.Fight;
            fightManager.Instance.Ennemi = collision.gameObject;
            setPosTp = true;
        }
    }
}
