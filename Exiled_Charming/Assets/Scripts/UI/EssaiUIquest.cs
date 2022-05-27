using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EssaiUIquest : MonoBehaviour
{
    public Image[] images;
    public List<Text> Texts;

    private int questInProgress;

  
    private void Start()
    {
        images = GetComponentsInChildren<Image>();
      
        for (int i = 0; i < transform.childCount; i++)
        {
            Texts.Add(transform.GetChild(i).GetChild(0).GetComponent<Text>());
            Texts[i].enabled = false;
        }

        for (int i = 0; i < images.Length; i++)
        {
            images[i].enabled = false;
        }
    }

    public void StartQuest(string text, int index)
    {
        //questInProgress++;
        images[index].enabled = true;
        Texts[index - 1].enabled = true;
        Texts[index - 1].text = text;
    }

    public void FinishQuest(int index)
    {
        images[index].enabled = false;
        Texts[index - 1].enabled = false;
        //questInProgress--;
    }
}
