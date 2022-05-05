using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridSystem : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private GameObject tile;
    [SerializeField] private Camera camMain;

    private void Update()
    {
        createGrid();
    }
    void createGrid()
    {
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                var spawnTiles = Instantiate(tile, new Vector3(x, y), Quaternion.identity);
                spawnTiles.name = $"Tile{x}{y}";

                var offTile = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && x % 2 == 0);
            }
        }
        camMain.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
    }
}
