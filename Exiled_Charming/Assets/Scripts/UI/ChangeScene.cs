using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// le change scene du menu qui permet d'appell� la bonne sc�ne gra�e a un string dans le on click
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
