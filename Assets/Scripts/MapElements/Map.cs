using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    Tile prototypeTile;

    [SerializeField]
    Vector2Int mapSize;

    public List<Transform> mapCoordinates => GetComponentsInChildren<Tile>().ToList().Select(x => x.transform).ToList();

    public void GenerateMap()
    {
        ClearMap();

        float startX = (1 - mapSize.x) / 2;
        float startY = (1 - mapSize.y) / 2;
        float startZ = -0.125f;

        for(int i = 0; i < mapSize.x; i++)
        {
            for(int j = 0; j < mapSize.y; j++)
            {
                var pos = new Vector3(i + startX, startZ, j + startY);
                Instantiate(prototypeTile, pos, Quaternion.identity, transform);
            }
        }
    }

    public void ClearMap()
    {
        var tiles = GetComponentsInChildren<Tile>();
        foreach(var tile in tiles)
        {
            DestroyImmediate(tile.gameObject);
        }
        mapCoordinates.Clear();
    }
}
