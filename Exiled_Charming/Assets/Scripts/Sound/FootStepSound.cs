using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSound : MonoBehaviour
{
    [SerializeField] AudioClip[] FootstepsClip;

    private AudioSource audiosources;
    private Movements movecomponent;
    private float timer;

    private void Start()
    {
        timer = 0.0f;
        audiosources = GetComponent<AudioSource>();
        movecomponent = GetComponent<Movements>();
    }

    private void Update()
    {
        //Know when i walk for play a rnd clip
        if (movecomponent.IsMoving)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0.5f;
                AudioClip clip = GetRDClip();
                audiosources.PlayOneShot(clip,0.2f);
            }
        }
    }

    //taking a rnd between 3
    private AudioClip GetRDClip()
    {
        int index = Random.Range(0, 3);
        return FootstepsClip[index];
    }
}
