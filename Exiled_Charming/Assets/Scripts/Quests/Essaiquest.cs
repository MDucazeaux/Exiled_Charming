using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Essaiquest : MonoBehaviour
{
    public static Essaiquest Instance;

    public TextMeshProUGUI showPrecision;
    public GameObject setActiveButton;
    public GameObject setNotActiveButton;

    public GameObject questObjects;

    private GameObject parentButton;
    public int index;

    public bool isActive = true;

    public string[] precisions;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        parentButton = this.gameObject.transform.parent.gameObject ;
    }

    void Update()
    {
        if (index < precisions.Length && isActive)
        { 
            showPrecision.text = precisions[index];
            questObjects.SetActive(true);
        }

        if(!isActive)
        {
            questObjects.SetActive(false);
        }
    }

    public void nextQuest()
    {
         index++;
    }

    public void activateQuest()
    {
        isActive = false;
        setActiveButton.SetActive(false);
        setNotActiveButton.SetActive(true);
    }

    public void inactiveQuest()
    {
        isActive = true;
        setActiveButton.SetActive(true);
        setNotActiveButton.SetActive(false);
    }
}