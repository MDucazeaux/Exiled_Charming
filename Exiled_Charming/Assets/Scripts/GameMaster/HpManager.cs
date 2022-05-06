using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpManager : MonoBehaviour
{
    public int BasedHP;
    public int heal;
    public int Hp;
    // Start is called before the first frame update
    void Start()
    {
        BasedHP = 100;
        heal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int level = transform.GetComponent<XpManager>().Level;
        //int hpEquipment = transform.GetComponentInChildren<Inventorycomponent>().HpStat;

        Hp = BasedHP + 10 * level + heal; // + hpEquipment;
    }
}
