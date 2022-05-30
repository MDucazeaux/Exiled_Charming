using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//change scene de la scene principal permettant de faire pop-up 2 options
public class changescenetest : MonoBehaviour
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
}
