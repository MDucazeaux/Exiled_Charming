using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
