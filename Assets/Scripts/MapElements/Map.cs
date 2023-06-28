using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    Tile prototypeTile;

    [SerializeField]
    Vector2Int mapSize;

    public Vector2Int MapSize => mapSize;

    public List<Transform> mapCoordinates => GetComponentsInChildren<Tile>().ToList().Select(x => x.transform).ToList();
    public Dictionary<(int x, int z), Tile> tileCoor = new();

    void Awake()
    {
        var tiles = GetComponentsInChildren<Tile>().ToList();
        tiles.ForEach(x => tileCoor.Add((x.xCoordinate, x.zCoordinate), x));
    }

    public void GenerateMap()
    {
        ClearMap();

        float startX = (1 - mapSize.x) / 2;
        float startZ = (1 - mapSize.y) / 2;
        float startY = -0.125f;

        for(int i = 0; i < mapSize.x; i++)
        {
            for(int j = 0; j < mapSize.y; j++)
            {
                var pos = new Vector3(i + startX, startY, j + startZ);
                var tile = Instantiate(prototypeTile, pos, Quaternion.identity, transform);
                tile.xCoordinate = i; tile.zCoordinate = j;
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
