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
    public int xpAmount;

    private int bonus;

    public Image HealthBarImage;
    public Text healthText;

    public gameManager gameM;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");

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
            fightManager.Instance.updateState(GameState.waitForStart);
            fightManager.Instance.Ennemi = null;
            Player.GetComponent<XpManager>().AddXp(xpAmount);
            gameM.updateState(gameState.Game);
            this.gameObject.SetActive(false);
        }

        if (Hp >= 70)
        {
            HealthBarImage.color = Color.green;
        }

        if (Hp <= 70)
        {
            HealthBarImage.color = Color.yellow;
        }

        if (Hp <= 30)
        {
            HealthBarImage.color = Color.red;
        }

        if(this.gameObject.GetComponent<XpManager>())
        {
            if(this.GetComponent<XpManager>().LevelUp)
            {
                maxHp *= 2;
                Hp *= 2;
                this.GetComponent<XpManager>().LevelUp = false;
            }
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

    public void SetHealthBar()
    {
        HealthBarImage.fillAmount = Hp / maxHp;
        healthText.text = Hp + " / " + maxHp;
    }
}
