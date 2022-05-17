using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryItemController : MonoBehaviour
{
    public Item item;

    public delegate void OnItemsChange();
    public OnItemsChange OnItemsChanges;

    public static InventoryItemController instance;

    public Button RemoveButton;
    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void Useitem()
    {
       if (CharacterStats.Instance.CurrentHealth < 100)
        {
            switch (item.itemType)
            {
                case Item.ItemType.Potion:
                    CharacterStats.Instance.IncreaseHealth(item.Value);
                    RemoveItem();
                    break;
            }
        }

        if (item is Equipment)
        {
            EquipmentManager.Instance.Equip(item as Equipment);
            RemoveItem();
        }
    }
}
