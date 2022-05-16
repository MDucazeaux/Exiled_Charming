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
        //switch (item.itemType)
        //{
        //    case Item.ItemType.Potion:
        //        PlayerUI.Instance.IncreaseHealth(item.Value);
        //        break;
        //    case Item.ItemType.Armor:
        //        PlayerUI.Instance.IncreaseArmor(item.Value);
        //        break;
        //    case Item.ItemType.Weopon:
        //        PlayerUI.Instance.IncreaseDamage(item.Value);
        //        break;
        //}

        if (item is Equipment)
            EquipmentManager.Instance.Equip(item as Equipment);

        RemoveItem();
    }
}
