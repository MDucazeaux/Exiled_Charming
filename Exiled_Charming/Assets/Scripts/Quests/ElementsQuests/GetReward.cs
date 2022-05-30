using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//distribute rewards when the player finish the tutorial
public class GetReward : MonoBehaviour
{
    public int xpGain;
    public Item[] itemsGained;
    public int moneyGain;

    private GameObject Player;
    private GameObject Inventory;

    public int indexRequired;

    private void Start()
    {
        Player = GameObject.Find("Player");
        Inventory = GameObject.Find("InventoryManager").gameObject;
            this.GetComponent<Button>().enabled = false ;
    }

    private void Update()
    {
        if(indexRequired == Essaiquest.Instance.index)
        {
            this.GetComponent<Button>().enabled = true;
            this.GetComponent<Image>().enabled = true;
        }
        else
        {
            this.GetComponent<Button>().enabled = false ;
            this.GetComponent<Image>().enabled = false ;
        }
    }
    public void getReward()
    {
        Player.GetComponent<XpManager>().AddXp(xpGain);

        for(int x = 0; x < itemsGained.Length; x++)
            Inventory.GetComponent<InventoryManager>().Add(itemsGained[x]);

        Essaiquest.Instance.nextQuest();

        this.gameObject.SetActive(false);
    }
}
