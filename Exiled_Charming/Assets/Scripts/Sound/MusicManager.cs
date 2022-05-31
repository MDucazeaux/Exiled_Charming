using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip Mtrip;
    public AudioClip MFight;
    public AudioClip Mcastle;
    public AudioClip SfButton;
    public AudioClip MCredits;

    private GameObject musicManager;
    private GameObject player;
    private GameObject gameManager;

    public bool PlayingFight;
    public bool PlayingCastle;
    public bool PlayingTrip;
    public bool PlayOnce;
    public bool PlayButton;
    public bool PlayCredits;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        PlayOnce = false;
        PlayingTrip = false;
        PlayingCastle = false;
        PlayingFight = false;
        PlayCredits = true;
    }

    private void Update()
    {
        if (!PlayOnce)
        {
            this.gameObject.GetComponent<AudioSource>().Stop();
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(Mcastle,0.3f);
            PlayOnce = true;
            PlayingFight = false;
            PlayingCastle = true;
        }

        if (PlayingFight)
        {
            this.gameObject.GetComponent<AudioSource>().Stop() ;
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(MFight, 0.3f);
            PlayingFight = false;
        }

        if (PlayButton)
        {
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(SfButton, .3f);
            PlayButton = false;
        }

        if(SceneManager.GetActiveScene().name == "Credit" && PlayCredits)
        {
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(MCredits, .3f);
            PlayCredits = false;
        }
        
    }
    
    public void loadmusic()
    {
        PlayButton = true;
    }
}
