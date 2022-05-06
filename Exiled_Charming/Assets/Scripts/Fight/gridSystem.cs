using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridSystem : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private tileColor tile;
    [SerializeField] private Camera camMain;
    public int x, y;

    private void Start()
    {
        createGrid();
    }
    void createGrid()
    {
        for(x = 0; x < width; x++)
        {
            for(y = 0; y < height; y++)
            {
                var spawnTiles = Instantiate(tile, new Vector3(x, y), Quaternion.identity);
                spawnTiles.name = $"Tile{x}{y}";

                var offTile = (x + y) % 2 == 1;
                tile.makeTiles(offTile);

            }
        }
        camMain.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
    }
}
