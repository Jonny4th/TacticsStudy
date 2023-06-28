using System.Collections.Generic;
using UnityEngine;

public class AlignPosition : MonoBehaviour, ICoordinateMoveable
{
    [SerializeField]
    Vector3 currentPosition;

    public Tile currentTile { get ; set; }

    [SerializeField]
    int xCoor = 0;

    [SerializeField]
    int zCoor = 0;

    public Tile CurrentTile => currentTile;
    Map map;
    Dictionary<(int x, int z), Tile> tileCoor => map.tileCoor;

    void Awake()
    {
        map = FindObjectOfType<Map>();
    }

    void Start()
    {
        AlignOnMapTile();
    }

    void AlignOnMapTile()
    {
        currentPosition = tileCoor[(xCoor, zCoor)].transform.position;
        currentPosition.y = 0;
        transform.position = currentPosition;

        GetCurrentTile();
    }

    void GetCurrentTile()
    {
        int layer = 1 << LayerMask.NameToLayer("Tile");
        Ray ray = new(transform.position + Vector3.up, transform.TransformDirection(Vector3.down));
        if(Physics.Raycast(ray, out RaycastHit hit, 2f, layer, QueryTriggerInteraction.Collide))
        {
            if(currentTile != null) currentTile.Deselect();
            currentTile = hit.transform.GetComponent<Tile>();
            currentTile.Select();
        }
    }

    public void XCoorIncrement(int x)
    {
        if(!tileCoor.TryGetValue((xCoor + x, zCoor), out var _)) return;

        xCoor += x;
        AlignOnMapTile();
    }
    
    public void ZCoorIncrement(int z)
    {
        if(!tileCoor.TryGetValue((xCoor, zCoor + z), out var _)) return;

        zCoor += z;
        AlignOnMapTile();
    }

    public void YCoorIncrement(int y)
    {
        throw new System.NotImplementedException();
    }
}
