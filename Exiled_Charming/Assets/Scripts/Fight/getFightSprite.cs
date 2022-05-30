using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//will set up the game object sprite so that it faces the good thing (if possible)
public class getFightSprite : MonoBehaviour
{
    public Sprite[] fightSprite;
    // Update is called once per frame
    void Update()
    {
        if(fightManager.Instance.state != GameState.waitForStart && this.tag != "Player")
        {
            this.GetComponent<SpriteRenderer>().sprite = fightSprite[0];
        }
        else if(fightManager.Instance.state != GameState.waitForStart && this.tag == "Player" && EquipmentManager.Instance.CurrentEquipment[0] != null)
        {
            if (EquipmentManager.Instance.CurrentEquipment[0].Id == 11)
            {
                this.GetComponent<SpriteRenderer>().sprite = fightSprite[1];
            }
            else if (EquipmentManager.Instance.CurrentEquipment[0].Id == 12)
            {
                this.GetComponent<SpriteRenderer>().sprite = fightSprite[2];
            }
            else if (EquipmentManager.Instance.CurrentEquipment[0].Id == 13)
            {
                this.GetComponent<SpriteRenderer>().sprite = fightSprite[3];
            }
        }
    }
}
