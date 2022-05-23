using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{
    public int BasedHP;
    public int heal;
    public float Hp;
    public float maxHp = 100;

    private int bonus;

    public Image HealthBarImage;
    public Text healthText;

    public gameManager gameM;

    // Start is called before the first frame update
    void Start()
    {
        BasedHP = 100;
        heal = 0;
        bonus = 0;
        Hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        //int level = transform.GetComponent<XpManager>().Level;
        //bonus = level * 10 + heal;
        //int hpEquipment = transform.GetComponentInChildren<Inventorycomponent>().HpStat;

        //Hp = BasedHP + bonus; // + hpEquipment;
        
        if(Hp > maxHp)
        {
            Hp = maxHp;
        }

        //if(Hp <= 0)
        //{
        //    this.gameObject.SetActive(false);
        //    Hp = 0;
        //}

        if(this.Hp <= 0 && this.tag == "ennemi")
        {
            this.gameObject.SetActive(false);
            fightManager.Instance.updateState(GameState.waitForStart);
            gameM.updateState(gameState.Game);
        }
    }

    public void dealDamage(int dmg)
    {
        Hp -= dmg;
        HealthBarImage.fillAmount = Hp / maxHp;
        healthText.text = Hp + " / " + maxHp;
    }

    public void healAmount()
    {
        Hp = 100;
        HealthBarImage.fillAmount = Hp / maxHp;
        healthText.text = Hp + " / " + maxHp;
    }
}
