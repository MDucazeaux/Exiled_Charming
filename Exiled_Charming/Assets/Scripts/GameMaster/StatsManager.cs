using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int Def;
    public int baseDef = 25;
    public int AD;
    public int baseAD = 10;

    void Start()
    {
        updateStats();
    }

    private void Update()
    {
    }
    // Update is called once per frame
    public void updateStats()
    {
        baseDef += 10 ;
        baseAD += 15;
    }
}
