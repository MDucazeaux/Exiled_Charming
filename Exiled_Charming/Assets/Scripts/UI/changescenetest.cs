using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescenetest : MonoBehaviour
{
    public GameObject Object;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && fightManager.Instance.state == GameState.waitForStart)
        {
            Object.SetActive(true);
        }
    }

    public void switchscene(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }
}
