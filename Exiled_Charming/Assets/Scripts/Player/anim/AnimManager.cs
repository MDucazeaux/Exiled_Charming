using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    //public Animator[] PlayerAnim;
    private Animator PlayerAnim;
    public int ArmorType = 0;
    public GameObject casual;
    public GameObject disguise;
    public GameObject steel;
    public GameObject gold;
    private bool wasMovingRight = false;
    private bool wasMovingLeft = false;
    private bool wasMovingUp = false;
    private bool wasMovingDown = false;
    private bool IsMooving = false;
    private int i;
    
    private void Start()
    {
        i = 0;
        PlayerAnim = this.gameObject.GetComponent<Animator>();
        
    }
    private void Update()
    {
        if(EquipmentManager.Instance.CurrentEquipment[0] == null)
        {
            ArmorType = 10;
        }
        else
        {

            ArmorType = EquipmentManager.Instance.CurrentEquipment[0].Id;
        }
        if (ArmorType == 10)
        {
            PlayerAnim.GetComponent<Animator>().runtimeAnimatorController = casual.GetComponent<Animator>().runtimeAnimatorController;
        }
        
        if(ArmorType == 11)
        {
            PlayerAnim.GetComponent<Animator>().runtimeAnimatorController = disguise.GetComponent<Animator>().runtimeAnimatorController;
        }
        
        if(ArmorType == 12)
        {
            PlayerAnim.GetComponent<Animator>().runtimeAnimatorController = steel.GetComponent<Animator>().runtimeAnimatorController;
        }
        
        if(ArmorType == 13)
        {
            PlayerAnim.GetComponent<Animator>().runtimeAnimatorController = gold.GetComponent<Animator>().runtimeAnimatorController;
        }

        float axeX = Input.GetAxisRaw("Horizontal");
        float axeY = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Q))
        {
            IsMooving = true;
            PlayerAnim.GetComponent<Animator>().SetInteger("Behaviour", 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            IsMooving = true;
            PlayerAnim.GetComponent<Animator>().SetInteger("Behaviour", 1);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            IsMooving = true;
            PlayerAnim.GetComponent<Animator>().SetInteger("Behaviour", 2);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            IsMooving = true;
            PlayerAnim.GetComponent<Animator>().SetInteger("Behaviour", 3);
        }
        
        if (axeX < 0)
        {
            IsMooving = true;
            PlayerAnim.GetComponent<Animator>().SetInteger("Behaviour", 0);
            wasMovingLeft = true;
            wasMovingUp = false;
            wasMovingRight = false;
            wasMovingDown = false;
        }
        if (axeX > 0)
        {
            IsMooving = true;
            PlayerAnim.GetComponent<Animator>().SetInteger("Behaviour", 1);
            wasMovingLeft = false;
            wasMovingUp = false;
            wasMovingRight = true;
            wasMovingDown = false;
        }
        if (axeY > 0)
        {
            IsMooving = true;
            PlayerAnim.GetComponent<Animator>().SetInteger("Behaviour", 2);
            wasMovingLeft = false;
            wasMovingUp = true;
            wasMovingRight = false;
            wasMovingDown = false;
        }
        if (axeY < 0)
        {
            IsMooving = true;
            PlayerAnim.GetComponent<Animator>().SetInteger("Behaviour", 3);
            wasMovingLeft = false;
            wasMovingUp = false;
            wasMovingRight = false;
            wasMovingDown = true;
        }

        if (Input.GetKeyUp(KeyCode.Z) || wasMovingUp && !IsMooving)
        {
            PlayerAnim.GetComponent<Animator>().SetInteger("Behaviour", -4);
        }

        if (Input.GetKeyUp(KeyCode.D) || wasMovingRight && !IsMooving)
        {
            PlayerAnim.GetComponent<Animator>().SetInteger("Behaviour", -3);
        }

        if (Input.GetKeyUp(KeyCode.Q) || wasMovingLeft && !IsMooving)
        {
            PlayerAnim.GetComponent<Animator>().SetInteger("Behaviour", -2);
        }

        if (Input.GetKeyUp(KeyCode.S) || wasMovingDown && !IsMooving)
        {
            PlayerAnim.GetComponent<Animator>().SetInteger("Behaviour", -1);
        }

        IsMooving = false;
    }
}

