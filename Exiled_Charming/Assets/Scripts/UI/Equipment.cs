using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Item/New Equipment")]

public class Equipment : Item
{
    public EquipmentSlot equipmentSlot;
    public int ArmorModifier;
    public int DamageModifier;
}

public enum EquipmentSlot { Armor, Weopon }