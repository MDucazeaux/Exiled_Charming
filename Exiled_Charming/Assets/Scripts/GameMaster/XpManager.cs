using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpManager : MonoBehaviour
{
    public int Level;
   
    public float xp;
    public float maxxp;

    public int xpGiven;

    public AudioClip levelUpAudio;

    public bool LevelUp;
    public Slider XPBarImage;
    public Text levelTxt;
    public Text xpTxtInventory;

    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
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

        if (this.tag == "ennemi")
        {

            this.GetComponentInChildren<TextMesh>().text = Level.ToString();

            if(this.GetComponent<HpManager>().Hp <= 0)
                player.GetComponent<XpManager>().AddXp(xpGiven);
        }
    }

    public void AddXp(int amount)
    {
        xp += amount;
    }
}
