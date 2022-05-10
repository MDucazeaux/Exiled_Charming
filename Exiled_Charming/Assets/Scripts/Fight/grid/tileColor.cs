using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileColor : MonoBehaviour
{
    [SerializeField] private Color color1, color2;
    [SerializeField] private SpriteRenderer rendererTile;
    [SerializeField] private GameObject tileOpen;

    public void makeTiles(bool offSet)
    {
        rendererTile.color = offSet ? color1 : color2;
    }

    void OnMouseEnter()
    {
        tileOpen.SetActive(true);
    }

    void OnMouseExit()
    {
        tileOpen.SetActive(false);
    }

}
