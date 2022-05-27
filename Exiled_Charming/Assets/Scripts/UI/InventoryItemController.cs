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
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
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
       if (player.GetComponent<HpManager>().Hp < 100)
        {
            switch (item.itemType)
            {
                case Item.ItemType.Potion:
                    GameObject player = GameObject.Find("Player");
                    player.GetComponent<HpManager>().healAmount();
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
