using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;
    public Toggle EnableRemove;
    public int NbPotion;

    public InventoryItemController[] InventoryItems;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (Items.Count>0)
        {

           // Debug.Log(Items[0].itemType);

        }
        
    }

    public void Add(Item item)
    {
        NbPotion = 0;
        
        Items.Add(item);
        foreach (Item items in Items)
        {
            if (items.itemType == Item.ItemType.Potion)
            {
                NbPotion += 1;
            }
        }
        ListItems();
    }

    public void Remove(Item item)
    {
        NbPotion = 0;
        
        Items.Remove(item);
        foreach (Item items in Items)
        {
            if (items.itemType == Item.ItemType.Potion)
            {
                NbPotion += 1;
            }
        }
        ListItems();
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();
            obj.transform.GetComponent<InventoryItemController>().item = item;
          
            itemName.text = item.ItemName;
            itemIcon.sprite = item.Icon;

            if (EnableRemove.isOn)
            {
                removeButton.gameObject.SetActive(true);
            }
        }
    }

    public void EnableItemsRemove()
    {
        if(EnableRemove.isOn)
        {
            foreach(Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }

        else
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }
}
