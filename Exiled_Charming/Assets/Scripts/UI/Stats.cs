using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

//script de base qui retourne les valeurs d'amure et de damage
public class Stats
{
    [SerializeField]
    public int baseValue;

    private List<int> Modifiers = new List<int>();

    public int GetValue ()
    {
        int finalValue = baseValue;
        Modifiers.ForEach(x => finalValue = +x);
        return finalValue;
    }
    
    public void AddModifier(int modifier)
    {
        if (modifier != 0)
            Modifiers.Add(modifier);
    }

    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
            Modifiers.Remove(modifier);
    }


}
