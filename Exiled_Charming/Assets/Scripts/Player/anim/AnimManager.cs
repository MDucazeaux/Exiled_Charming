using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    //public Animator[] playerAnim;
    private Animator playerAnim;
    public GameObject Casual;
    public GameObject Disguise;
    public GameObject Steel;
    public GameObject Gold;
    private bool wasMovingRight = false;
    private bool wasMovingLeft = false;
    private bool wasMovingUp = false;
    private bool wasMovingDown = false;
    private bool IsMooving = false;
    private int i;
    public int ArmorType = 0;
    private void Start()
    {
        i = 0;
        playerAnim = this.gameObject.GetComponent<Animator>();
        
    }
    private void Update()
    {
        //To know what armor we are wearing
        if (ArmorType == 0)
        {
            playerAnim.GetComponent<Animator>().runtimeAnimatorController = Casual.GetComponent<Animator>().runtimeAnimatorController;
        }
        
        if(ArmorType == 1)
        {
            playerAnim.GetComponent<Animator>().runtimeAnimatorController = Disguise.GetComponent<Animator>().runtimeAnimatorController;
        }
        
        if(ArmorType == 2)
        {
            playerAnim.GetComponent<Animator>().runtimeAnimatorController = Steel.GetComponent<Animator>().runtimeAnimatorController;
        }
        
        if(ArmorType == 3)
        {
            playerAnim.GetComponent<Animator>().runtimeAnimatorController = Gold.GetComponent<Animator>().runtimeAnimatorController;
        }

        //To accord all the animation with the movement
        //For the keyboard
        float axeX = Input.GetAxisRaw("Horizontal");
        float axeY = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Q))
        {
            IsMooving = true;
            playerAnim.GetComponent<Animator>().SetInteger("Behaviour", 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            IsMooving = true;
            playerAnim.GetComponent<Animator>().SetInteger("Behaviour", 1);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            IsMooving = true;
            playerAnim.GetComponent<Animator>().SetInteger("Behaviour", 2);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            IsMooving = true;
            playerAnim.GetComponent<Animator>().SetInteger("Behaviour", 3);
        }
        
        //And for the gamepad
        if (axeX < 0)
        {
            IsMooving = true;
            playerAnim.GetComponent<Animator>().SetInteger("Behaviour", 0);
            wasMovingLeft = true;
            wasMovingUp = false;
            wasMovingRight = false;
            wasMovingDown = false;
        }
        if (axeX > 0)
        {
            IsMooving = true;
            playerAnim.GetComponent<Animator>().SetInteger("Behaviour", 1);
            wasMovingLeft = false;
            wasMovingUp = false;
            wasMovingRight = true;
            wasMovingDown = false;
        }
        if (axeY > 0)
        {
            IsMooving = true;
            playerAnim.GetComponent<Animator>().SetInteger("Behaviour", 2);
            wasMovingLeft = false;
            wasMovingUp = true;
            wasMovingRight = false;
            wasMovingDown = false;
        }
        if (axeY < 0)
        {
            IsMooving = true;
            playerAnim.GetComponent<Animator>().SetInteger("Behaviour", 3);
            wasMovingLeft = false;
            wasMovingUp = false;
            wasMovingRight = false;
            wasMovingDown = true;
        }

        if (Input.GetKeyUp(KeyCode.Z) || wasMovingUp && !IsMooving)
        {
            playerAnim.GetComponent<Animator>().SetInteger("Behaviour", -4);
        }

        if (Input.GetKeyUp(KeyCode.D) || wasMovingRight && !IsMooving)
        {
            playerAnim.GetComponent<Animator>().SetInteger("Behaviour", -3);
        }

        if (Input.GetKeyUp(KeyCode.Q) || wasMovingLeft && !IsMooving)
        {
            playerAnim.GetComponent<Animator>().SetInteger("Behaviour", -2);
        }

        if (Input.GetKeyUp(KeyCode.S) || wasMovingDown && !IsMooving)
        {
            playerAnim.GetComponent<Animator>().SetInteger("Behaviour", -1);
        }

        IsMooving = false;
    }
}

