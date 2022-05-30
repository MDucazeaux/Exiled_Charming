using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//load menu quand on press enter
public class Changesceneavantmenu : MonoBehaviour
{

    public AudioClip SfButton;

    public bool activetimer;
    public float timer = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activetimer == true)
        {
            timer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            activetimer = true;
        }

        if (timer <= 0)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(SfButton, 0.2f);
            SceneManager.LoadScene("Menu");
            
            timer = 0.7f;
        }
    }
}