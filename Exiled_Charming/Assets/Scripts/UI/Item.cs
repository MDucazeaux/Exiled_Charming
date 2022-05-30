using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//données pour tout mes items 

[CreateAssetMenu(fileName = "New item", menuName = "Item/New Item")]
public class Item : ScriptableObject
{
    public int Id;
    public string ItemName;
    public int Value;
    public Sprite Icon;
    public ItemType itemType;

    public enum ItemType
    {
        Potion,
        Armor,
        Weopon
    }
}

