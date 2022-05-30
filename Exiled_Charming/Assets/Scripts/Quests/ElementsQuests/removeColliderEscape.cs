using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the game object that has this component usually block the exit of the castle, itll be removed once the player finished it
public class removeColliderEscape : MonoBehaviour
{
    private void Update()
    {
        if(Essaiquest.Instance.index == 5)
        {
            this.gameObject.SetActive(false);
        }
    }
}
