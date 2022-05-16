using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestVisualiser : MonoBehaviour
{
    public GameObject QuestPanel;
    public bool InstanPanel = false;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI  BodyText;
    void Update()
    {
        if(InstanPanel)
        {
            QuestPanel.SetActive(true);
            NameText.text = "Prince";
            BodyText.text = "Bonjour je suis t'as gra-mer";
        }
        else
        {
            NameText.text = null;
            BodyText.text = null;
            QuestPanel.SetActive(false);
        }
    }
}
