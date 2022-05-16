using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI Instance;
    public Equipment equipment;

    public int Health;
    public int Damage;
    public int Armor;

    public Text HealthTxt;
    public Text DamageTxt;
    public Text ArmorTxt;

    private void Awake()
    {
        Instance = this;
    }
   
    public void IncreaseHealth(int value)
    {
        Health += value;
        HealthTxt.text = $"HP : {Health}";
    }

    public void IncreaseDamage(int value)
    {
        Damage += equipment.DamageModifier;
        DamageTxt.text = $"Damage : {Damage}";
    }

    public void IncreaseArmor(int value)
    {
        Armor += value;
        ArmorTxt.text = $"Armor : {Armor}";
    }
}
