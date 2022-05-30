using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//script permettant de ramasser mes objets 
public class ItemPickUp : MonoBehaviour
{
    public Item Item;
    public Transform ItemContent;
    public GameObject InventoryItem;
    void pickup()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        pickup();
    }
}
