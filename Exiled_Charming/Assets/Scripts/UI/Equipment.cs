using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//scriptable object enfant de item qui recupère toute ces valeurs et lui attribue des nouvelles données spécifique a l'équipement
[CreateAssetMenu(fileName = "New Equipment", menuName = "Item/New Equipment")]

public class Equipment : Item
{
    public EquipmentSlot equipmentSlot;
    public int ArmorModifier;
    public int DamageModifier;
}

public enum EquipmentSlot { Armor, Weopon }