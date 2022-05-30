using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{

    public MusicManager MusicMana;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Trigger if we walk on this gameobject
        if (collision.gameObject.CompareTag("TriggerCastle") && !MusicMana.PlayingCastle)
        {
            MusicMana.gameObject.GetComponent<AudioSource>().Stop();
            MusicMana.PlayingTrip = false;
            MusicMana.PlayingFight = false;
            MusicMana.gameObject.GetComponent<AudioSource>().PlayOneShot(MusicMana.Mcastle, 0.2f);
            MusicMana.PlayingCastle = true;
        }

        //if (collision.gameObject.CompareTag("TriggerFight") && !MusicMana.PlayingFight)
        //{
        //    MusicMana.gameObject.GetComponent<AudioSource>().Stop();
        //    MusicMana.PlayingCastle = false;
        //    MusicMana.PlayingTrip = false;
        //    MusicMana.gameObject.GetComponent<AudioSource>().PlayOneShot(MusicMana.MFight, 0.2f);
        //    MusicMana.PlayingFight = true;
        //}

        if (collision.gameObject.CompareTag("TriggerTrip") && !MusicMana.PlayingTrip)
        {
            MusicMana.gameObject.GetComponent<AudioSource>().Stop();
            MusicMana.PlayingFight = false;
            MusicMana.PlayingCastle = false;
            MusicMana.gameObject.GetComponent<AudioSource>().PlayOneShot(MusicMana.Mtrip, 0.2f);
            MusicMana.PlayingTrip = true;
        }

    }
}
