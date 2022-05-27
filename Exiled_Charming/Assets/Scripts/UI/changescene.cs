using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescene : MonoBehaviour
{
    public void switchscene(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
