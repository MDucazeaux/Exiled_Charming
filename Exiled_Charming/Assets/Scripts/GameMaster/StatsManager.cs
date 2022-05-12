using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int Def;
    public int AD;
    public int BaseAd;
    public int BaseDef;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int level = transform.GetComponent<XpManager>().Level;

        Def = BaseDef + 10 * level;//+ Stats armure
        AD = BaseAd + 15 * level;// + Stats armure

        if (transform.GetComponent<Movements>())
        {
            if (SaveManager.instance.HasLoaded)
            {
                BaseDef = SaveManager.instance.ActiveSave.DefSaved;
                BaseAd = SaveManager.instance.ActiveSave.ADSaved;
            }

            SaveManager.instance.ActiveSave.DefSaved = BaseDef;
            SaveManager.instance.ActiveSave.ADSaved = BaseAd;

        }
       
    }
}
