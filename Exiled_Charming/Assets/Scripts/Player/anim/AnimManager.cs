using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    public Animator PlayerAnim;
    public int ArmorType = 0;
    public GameObject[] playerVisuals;
    private void Start()
    {
        //playerAnim = GetComponent<Animator>();
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerAnim.SetInteger("Behaviour", 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerAnim.SetInteger("Behaviour", 1);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayerAnim.SetInteger("Behaviour", 2);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerAnim.SetInteger("Behaviour", 3);
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            PlayerAnim.SetInteger("Behaviour", -2);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            PlayerAnim.SetInteger("Behaviour", -3);
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            PlayerAnim.SetInteger("Behaviour", -4);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            PlayerAnim.SetInteger("Behaviour", -1);
        }
    }
}

