using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//this component will manage the hp of the game object that has it, itll also manage the level up for the hp but NOT THE XP GAINED

public class HpManager : MonoBehaviour
{
    public int BasedHP;
    public float Hp;
    public float maxHp;

    public Image HealthBarImage;
    public Text healthText;

    public gameManager gameM;
    private GameObject Player;


    void Start()
    {
        Player = GameObject.Find("Player");
        Hp = maxHp;
        SetHealthBar();
    }


    void Update()
    {
        if(Hp < 0)
        {
            Hp = 0;
        }

        if(this.Hp <= 0 && this.tag == "ennemi")
        {
            fightManager.Instance.updateState(GameState.waitForStart);
            fightManager.Instance.Ennemi = null;
            gameM.updateState(gameState.Game);
            this.gameObject.SetActive(false);
        }

        if(this.tag == "ennemi")
        {

            SetHealthBar();
            if (Hp >= maxHp / 2)
            {
                HealthBarImage.color = Color.green;
            }

            if (Hp <= maxHp / 2)
            {
                HealthBarImage.color = Color.yellow;
            }

            if (Hp <= maxHp / 4)
            {
                HealthBarImage.color = Color.red;
            }

            if(Hp <= 0)
            {
                Player.GetComponent<XpManager>().AddXp(this.GetComponent<XpManager>().xpGiven);
            }
        }

        if(this.gameObject.GetComponent<XpManager>())
        {
            if(this.GetComponent<XpManager>().LevelUp)
            {
                maxHp *= 2;
                Hp *= 2;
                HealthBarImage.fillAmount = Hp / maxHp;
                healthText.text = Hp + " / " + maxHp;
                this.GetComponent<XpManager>().LevelUp = false;
            }
        }

        SetHealthBar();
    }

    public void dealDamage(int dmg)
    {
        Hp = Hp + this.GetComponent<StatsManager>().baseDef -  dmg;

        if (Hp > maxHp)
        {
            Hp = maxHp;
        }

        HealthBarImage.fillAmount = Hp / maxHp;
        healthText.text = Hp + " / " + maxHp;
    }

    public void healAmount()
    {
        Hp += 100;
        if (Hp > maxHp)
        {
            Hp = maxHp;
        }
        HealthBarImage.fillAmount = Hp / maxHp;
        healthText.text = Hp + " / " + maxHp;
    }

    public void SetHealthBar()
    {
        HealthBarImage.fillAmount = Hp / maxHp;
        healthText.text = Hp + " / " + maxHp;
    }
}
