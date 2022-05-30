using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip Mtrip;
    public AudioClip MFight;
    public AudioClip Mcastle;

    private GameObject musicManager;
    private GameObject player;
    private GameObject gameManager;

    public bool PlayingFight;
    public bool PlayingCastle;
    public bool PlayingTrip;
    public bool PlayOnce;
    public bool PlayButton;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        PlayOnce = false;
        PlayingTrip = false;
        PlayingCastle = false;
        PlayingFight = false;
    }

    private void Update()
    {
        if (!PlayOnce)
        {
            this.gameObject.GetComponent<AudioSource>().Stop();
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(Mcastle, 0.2f);
            PlayOnce = true;
            PlayingFight = false;
            PlayingCastle = true;
        }

        if (PlayingFight)
        {
            this.gameObject.GetComponent<AudioSource>().Stop() ;
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(MFight, 0.2f);
            PlayingFight = false;
        }
    }
    
   

}
