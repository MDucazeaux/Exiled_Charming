using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//this component will manage all the experience that the player can get during his game. 
//the enemies also have this component to have a level and be able to give the player some xp. 
//the xp is given depending on the level difference between them and the player. its always updated since the player can level up.

public class XpManager : MonoBehaviour
{
    private int lvlDiff;

    public int Level;
   
    public float xp;
    public float maxxp;

    public int xpGiven;

    public AudioClip levelUpAudio;

    public bool LevelUp;
    public Slider XPBarImage;
    public Text levelTxt;
    public Text xpTxtInventory;

    public TextMesh lvlMobs;

    private GameObject player;
    private bool setVariables = false;
    void Start()
    {
        player = GameObject.Find("Player"); 

        if (!setVariables)
        {
            switch (Level)
            {
                case < 2:
                    this.GetComponent<HpManager>().Hp = 200;
                    this.GetComponent<HpManager>().maxHp = 200;
                    setVariables = true;
                    break;
                case < 4:
                    this.GetComponent<HpManager>().Hp = 800;
                    this.GetComponent<HpManager>().maxHp = 800;
                    setVariables = true;
                    break;
                case < 6:
                    this.GetComponent<HpManager>().Hp = 2000;
                    this.GetComponent<HpManager>().maxHp = 2000;
                    setVariables = true;
                    break;
                case < 8:
                    this.GetComponent<HpManager>().Hp = 3000;
                    this.GetComponent<HpManager>().maxHp = 3000;
                    setVariables = true;
                    break;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject == player)
        {
            XPBarImage.maxValue = maxxp;
            XPBarImage.value = xp;

            levelTxt.text = Level.ToString() ;
            xpTxtInventory.text = "Xp : " + xp.ToString() + "/" + maxxp.ToString() ;

            if (xp >= maxxp)
            {
                Level += 1;
                xp = xp - maxxp;
                maxxp *= 2;
                this.GetComponent<StatsManager>().updateStats();
                this.GetComponent<AudioSource>().PlayOneShot(levelUpAudio, 0.5f);
                LevelUp = true;
            }
        }

        if (this.tag == "ennemi" && this.transform.parent != null && !this.GetComponent<dialoguePnj>())
        {
            lvlMobs.text = Level.ToString();

            lvlDiff = this.Level - player.GetComponent<XpManager>().Level;

            switch (lvlDiff)
            {
                case < -2:
                    xpGiven = 0;
                    break;
                case -2:
                    xpGiven = 10;
                    break;
                case -1:
                    xpGiven = 50;
                    break;
                case 0:
                    xpGiven = 100;
                    break;
                case 1:
                    xpGiven = 150;
                    break;
                case 2:
                    xpGiven = 200;
                    break;
                case > 2:
                    xpGiven = 300;
                    break;
            }


        }
    }

    public void AddXp(int amount)
    {
        xp += amount;
    }
}
