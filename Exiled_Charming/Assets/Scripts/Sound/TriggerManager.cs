using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{

    public MusicManager musicManager;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TriggerCastle") && !musicManager.PlayingCastle)
        {
            musicManager.gameObject.GetComponent<AudioSource>().Stop();
            musicManager.PlayingTrip = false;
            musicManager.PlayingFight = false;
            musicManager.gameObject.GetComponent<AudioSource>().PlayOneShot(musicManager.Mcastle, 0.2f);
            musicManager.PlayingCastle = true;
        }

        if (collision.gameObject.CompareTag("TriggerTrip") && !musicManager.PlayingTrip)
        {
            musicManager.gameObject.GetComponent<AudioSource>().Stop();
            musicManager.PlayingFight = false;
            musicManager.PlayingCastle = false;
            musicManager.gameObject.GetComponent<AudioSource>().PlayOneShot(musicManager.Mtrip, 0.2f);
            musicManager.PlayingTrip = true;
        }

    }
}
