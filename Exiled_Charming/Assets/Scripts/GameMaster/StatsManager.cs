using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int Def;
    public int AD;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int level = transform.GetComponent<XpManager>().Level;

        Def = Def + 10 * level;
        AD = AD + 15 * level;
        
    }
}
