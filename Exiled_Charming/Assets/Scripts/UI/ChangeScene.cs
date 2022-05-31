using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// le change scene du menu qui permet d'appellé la bonne scène graçe a un string dans le on click
public class changescene : MonoBehaviour
{

    private float timer;

    bool activescene1;
    bool activescene2;
    bool activescene3;
    
    public void Start()
    {
        timer = 0.7f;
    }

    public void Update()
    {
        if(activescene1 == true)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                SceneManager.LoadScene("pickGame", LoadSceneMode.Single);
                timer = 0.7f;
            }

        }

        if (activescene2 == true)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                SceneManager.LoadScene("Credit", LoadSceneMode.Single);
                
                timer = 0.7f;
            }
        }

        if (activescene3 == true)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                SceneManager.LoadScene("Menu", LoadSceneMode.Single);
                timer = 0.7f;
            }
        }
    }

    public void switchscene()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void switchscene1()
    {
        activescene1 = true;
    }
    public void switchscene2()
    {
        activescene2 = true;
    }
    public void switchscene3()
    {
       activescene3 = true;
    }
   
    public void quitGame()
    {
        Application.Quit();
    }
}
