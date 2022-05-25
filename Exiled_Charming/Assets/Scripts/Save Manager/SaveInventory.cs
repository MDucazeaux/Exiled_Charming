using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveInventory : MonoBehaviour
{
    public Sprite[] AllInventorySprite;

    // Start is called before the first frame update
    void Start()
    {
        string dataPath = Application.persistentDataPath;
        Debug.Log(dataPath + "/Testinventorysave.txt");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void InventorySave()
    {
        for (int i = 0; i < InventoryManager.Instance.Items.Count; i++)
        {
            Item item = InventoryManager.Instance.Items[i];

            string dataPath = Application.persistentDataPath;
            File.AppendAllText
            (
                // Saves object index
                dataPath+"\\Testinventorysave.txt", "Object " + i.ToString() + "\n" +

                // Saves object properties
                item.name + "\n" +
                item.Id.ToString() + "\n" +
                item.Value.ToString() + "\n" +
                item.Icon.name + "\n" +
                item.itemType + "\n\n"
            ) ;
        }
    }


    public void LoadInventory()
    {
        string dataPath = Application.persistentDataPath;
        StreamReader reader = new StreamReader(dataPath + "\\Testinventorysave.txt");

        string text = reader.ReadToEnd();
        reader.Close();
        string[] lines = text.Split("\n");

        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains("Object"))
            {
                string name = lines[i + 1];
                int id = int.Parse(lines[i + 2]);
                int value = int.Parse(lines[i + 3]);
                Sprite icon = StringToSprite(lines[i + 4]);
                Item.ItemType itemtype = StringToItemType(lines[i + 5]);

                Item itemsaved = new Item();
                itemsaved.ItemName = name;
                itemsaved.Id = id;
                itemsaved.Value = value;
                itemsaved.Icon = icon;
                itemsaved.itemType = itemtype;

                InventoryManager.Instance.Add(itemsaved);
            }
        }
    }


    public Sprite StringToSprite(string name)
    {
        foreach(Sprite sprite in AllInventorySprite)
        {
            if (sprite.name == name)
            {
                return sprite;
            }
        }
        return null;
    }

    public Item.ItemType StringToItemType(string name)
    {
        Item.ItemType itemType = Item.ItemType.Armor;
        if (name == Item.ItemType.Potion.ToString())
        {
            itemType = Item.ItemType.Potion;
        }
        if (name == Item.ItemType.Armor.ToString())
        {
            itemType = Item.ItemType.Armor;
        }
        if (name == Item.ItemType.Weopon.ToString())
        {
            itemType = Item.ItemType.Weopon;
        }

        return itemType;
    }

        
}