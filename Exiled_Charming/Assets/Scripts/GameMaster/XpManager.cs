using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpManager : MonoBehaviour
{
    public int Level;
   
    public float xp;
    public float maxxp;

    public AudioClip levelUpAudio;

    public bool LevelUp;
    public Slider XPBarImage;
    public Text levelTxt;
    void Start()
    {
        maxxp = 1000f;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.tag == "Player")
        {
            XPBarImage.maxValue = maxxp;
            XPBarImage.value = xp;

            levelTxt.text = Level.ToString() ;
        }

        if (xp >= maxxp)
        {
            Level += 1;
            maxxp *= 2;
            xp = 0;


            if (this.tag == "Player")
            {
                this.GetComponent<AudioSource>().PlayOneShot(levelUpAudio, 0.5f);
                LevelUp = true;
            }
        }
    }

    public void AddXp(int amount)
    {
        xp += amount;
    }
}
