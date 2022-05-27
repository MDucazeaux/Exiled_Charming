using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescene : MonoBehaviour
{
    public GameObject Object;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Object.SetActive(true);
        }
    }

    public void switchscene(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
