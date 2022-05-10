using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionHighLight : MonoBehaviour
{
    public bool dealDamage;

    private GameObject ennemi;

    void dealDamageToEnemy()
    {
        if (dealDamage && GetComponentInParent<attackType>().isValided)
        {
            ennemi.GetComponent<HpManager>().BasedHP -= this.GetComponentInParent<StatsManager>().AD;
            dealDamage = false;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "ennemi")
        {
            ennemi = other.gameObject;
            dealDamage = true;

            dealDamageToEnemy(),
        }
    }
}
