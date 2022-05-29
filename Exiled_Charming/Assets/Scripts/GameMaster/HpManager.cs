using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{
    public int BasedHP;
    public float Hp;
    public float maxHp;

    public Image HealthBarImage;
    public Text healthText;

    public gameManager gameM;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Hp = maxHp;
        SetHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.Hp <= 0 && this.tag == "ennemi")
        {
            fightManager.Instance.updateState(GameState.waitForStart);
            fightManager.Instance.Ennemi = null;
            gameM.updateState(gameState.Game);
            this.gameObject.SetActive(false);
        }

        if(this.tag == "ennemi")
        {
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
