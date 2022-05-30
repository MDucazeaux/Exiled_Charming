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
        if(!PlayOnce)
        {
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(Mcastle,0.2f);
            PlayOnce = true;
            PlayingCastle = true;
        }
    }
    
   

}
