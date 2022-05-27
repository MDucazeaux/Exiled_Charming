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
    void Start()
    {
        maxxp = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        XPBarImage.maxValue = maxxp;
        XPBarImage.value = xp;

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
