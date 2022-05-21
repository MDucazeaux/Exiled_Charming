using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridSystem : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private tileColor tile;
    [SerializeField] private Camera camMain;
    public int x, y;

    private Dictionary<Vector2, tileColor> tiles;

    public void createGrid()
    {
        tiles = new Dictionary<Vector2, tileColor>();
        for(x = 0; x < width; x++)
        {
            for(y = 0; y < height; y++)
            {
                var spawnTiles = Instantiate(tile, new Vector3(x, y), Quaternion.identity);
                spawnTiles.name = $"Tile{x}{y}";
                spawnTiles.transform.SetParent(gameObject.transform);

                var offTile = (x + y) % 2 == 1;
                tile.makeTiles(offTile);

                tiles[new Vector2(x, y)] = spawnTiles;

                if(y >= height && x >= width)
                {
                    camMain.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
                }

            }
        }
    }

    public void clearDictionary()
    {
        tiles.Clear();
    }
    public tileColor tilePosition(Vector2 tilePos) //?
    {
        if(tiles.TryGetValue(tilePos,out var tile))
        {
            return tile;
        }
        return null;
    }
}
