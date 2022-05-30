using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//script permettant l'ajout de nouvelles statistique ( en l'occurence du damage et de l'armure ) via l'équipement
public class PlayerStats : CharacterStats
{
    public void Start()
    {
        EquipmentManager.Instance.onEquipmentChanged += OnEquipmentChanged;
    }

    public void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            Armor.AddModifier(newItem.ArmorModifier);
            Damage.AddModifier(newItem.DamageModifier);
        }

        if (oldItem != null)
        {
            Armor.RemoveModifier(oldItem.ArmorModifier);
            Damage.RemoveModifier(oldItem.DamageModifier);
        }
    }
}
