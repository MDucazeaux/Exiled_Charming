using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpManager : MonoBehaviour
{
    public int Hp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int level = transform.GetComponent<XpManager>().Level;
        //int hpEquipment = transform.GetComponentInChildren<Inventorycomponent>().HpStat;

        Hp = 100 + 10 * level; // + hpEquipment;
    }
}
