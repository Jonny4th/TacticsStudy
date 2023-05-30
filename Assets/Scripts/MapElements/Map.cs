using System;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    Tile prototypeTile;

    [SerializeField]
    Vector2Int mapSize;

    List<Transform> mapCoordinates = new();

    public void GenerateMap()
    {
        ClearMap();

        float startX = (1 - mapSize.x)/2;
        float startY = (1 - mapSize.y)/2;

        for(int i = 0; i < mapSize.x; i++)
        {
            for(int j = 0; j < mapSize.y; j++)
            {
                var pos = new Vector3(i + startX, 0, j + startY);
                mapCoordinates.Add(Instantiate(prototypeTile, pos, Quaternion.identity, transform).transform);
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
