using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpManager : MonoBehaviour
{
    public int Level;

    public float Xp;
    private float basemaxxp;
    private float maxXP;
    void Start()
    {
        basemaxxp = 10f;
        
    }

    // Update is called once per frame
    void Update()
    {
       if (transform.GetComponent<Movements>())
        {
            if (SaveManager.instance.HasLoaded)
            {
                Level = SaveManager.instance.ActiveSave.LevelSaved;
                maxXP = SaveManager.instance.ActiveSave.MaxXpSaved;
                Xp = SaveManager.instance.ActiveSave.XpSaved;
            }
            if (maxXP<1)
            {
                maxXP = 10f;
            }
            else
            {

                maxXP = basemaxxp * Level;
            }
        if (Xp >= maxXP)
        {
            Level += 1;
            Xp = 0;

        }
           
            SaveManager.instance.ActiveSave.LevelSaved = Level;
            SaveManager.instance.ActiveSave.MaxXpSaved = basemaxxp;
            SaveManager.instance.ActiveSave.XpSaved = Xp;
        }





    }
}
