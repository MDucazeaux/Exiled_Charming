using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Essaiquest : MonoBehaviour
{
    public TextMeshProUGUI showPrecision;

    private GameObject parentButton;
    private int index;

    public string[] precisions;

    private void Start()
    {
        parentButton = this.gameObject.transform.parent.gameObject ;
    }

    void Update()
    {
        if (index < precisions.Length)
        { 
            showPrecision.text = precisions[index];
            nextQuest();
        }
    }

    void nextQuest()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            index++;
            showPrecision.text = precisions[index];
        }
    }
}