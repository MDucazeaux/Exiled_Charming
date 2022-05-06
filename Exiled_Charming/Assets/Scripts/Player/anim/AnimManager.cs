using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    public Animator PlayerAnim;
    public int ArmorType = 0;
    public GameObject[] playerVisuals;
    private bool wasMovingRight = false;
    private bool wasMovingLeft = false;
    private bool wasMovingUp = false;
    private bool wasMovingDown = false;
    private bool IsMooving = false;
    private void Start()
    {
        //playerAnim = GetComponent<Animator>();
    }
    private void Update()
    {

        float axeX = Input.GetAxisRaw("Horizontal");
        float axeY = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Q))
        {
            IsMooving = true;
            PlayerAnim.SetInteger("Behaviour", 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            IsMooving = true;
            PlayerAnim.SetInteger("Behaviour", 1);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            IsMooving = true;
            PlayerAnim.SetInteger("Behaviour", 2);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            IsMooving = true;
            PlayerAnim.SetInteger("Behaviour", 3);
        }
        
        if (axeX < 0)
        {
            IsMooving = true;
            PlayerAnim.SetInteger("Behaviour", 0);
            wasMovingLeft = true;
            wasMovingUp = false;
            wasMovingRight = false;
            wasMovingDown = false;
        }
        if (axeX > 0)
        {
            IsMooving = true;
            PlayerAnim.SetInteger("Behaviour", 1);
            wasMovingLeft = false;
            wasMovingUp = false;
            wasMovingRight = true;
            wasMovingDown = false;
        }
        if (axeY > 0)
        {
            IsMooving = true;
            PlayerAnim.SetInteger("Behaviour", 2);
            wasMovingLeft = false;
            wasMovingUp = true;
            wasMovingRight = false;
            wasMovingDown = false;
        }
        if (axeY < 0)
        {
            IsMooving = true;
            PlayerAnim.SetInteger("Behaviour", 3);
            wasMovingLeft = false;
            wasMovingUp = false;
            wasMovingRight = false;
            wasMovingDown = true;
        }

        

        if (Input.GetKeyUp(KeyCode.Q) || wasMovingLeft && !IsMooving)
        {
            PlayerAnim.SetInteger("Behaviour", -2);
        }

        if (Input.GetKeyUp(KeyCode.D) || wasMovingRight && !IsMooving)
        {
            PlayerAnim.SetInteger("Behaviour", -3);
        }

        if (Input.GetKeyUp(KeyCode.Z) || wasMovingUp && !IsMooving)
        {
            PlayerAnim.SetInteger("Behaviour", -4);
        }

        if (Input.GetKeyUp(KeyCode.S) || wasMovingDown && !IsMooving)
        {
            PlayerAnim.SetInteger("Behaviour", -1);
        }

        IsMooving = false;
    }
}

