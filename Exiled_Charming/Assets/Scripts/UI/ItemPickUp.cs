using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//script permettant de ramasser mes objets 
public class ItemPickUp : MonoBehaviour
{
    public Item Item;
    public Transform ItemContent;
    public GameObject InventoryItem;

    private AudioSource PlayerAudio;
    public AudioClip pickupSound;

    private void Start()
    {
        PlayerAudio = GameObject.Find("Player").GetComponent<AudioSource>();
    }
    void pickup()
    {
        InventoryManager.Instance.Add(Item);
        PlayerAudio.PlayOneShot(pickupSound, 0.5f);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        pickup();
    }
}
