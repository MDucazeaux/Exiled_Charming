using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this component give defense and attack damage to the entity (player, enemies) depending on their level
public class StatsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int Def;
    public int baseDef;
    public int AD;
    public int baseAD;

    void Start()
    {
        if (this.tag == "Player")
            updateStats();
    }

    private void Update()
    {
        if(this.tag == "ennemi")
        {
            switch(this.GetComponent<XpManager>().Level)
            {
                case < 2:baseDef = 10; baseAD = 20;
                    break;
                case < 4:
                    baseDef = 25; baseAD = 50;
                    break;
                case < 6:
                    baseDef = 40; baseAD = 80;
                    break;
                case < 8:
                    baseDef = 80; baseAD = 150;
                    break;
            }
        }
    }
    // Update is called once per frame
    public void updateStats()
    {
        baseDef += 10 ;
        baseAD += 25;
    }
}
