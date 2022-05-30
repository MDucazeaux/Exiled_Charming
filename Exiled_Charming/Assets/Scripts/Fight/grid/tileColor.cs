using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the color of the ground only(2 colors 1/2)
public class tileColor : MonoBehaviour
{
    [SerializeField] private Color color1, color2;
    [SerializeField] private SpriteRenderer rendererTile;
    [SerializeField] private GameObject tileOccuped;

    private GameObject tile = null;

    public void makeTiles(bool offSet)
    {
        rendererTile.color = offSet ? color1 : color2; //ground colors
    }

}
