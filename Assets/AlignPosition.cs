using UnityEngine;

public class AlignPosition : MonoBehaviour
{
    [SerializeField]
    Vector3 currentPosition;

    [SerializeField]
    Tile currentTile;

    void Start()
    {
        AlignOnMapTile();
    }

    void AlignOnMapTile()
    {
        Map map = FindObjectOfType<Map>();
        var positions = map.mapCoordinates;
        var index = Random.Range(0, positions.Count);
        currentPosition = positions[index].position;
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
            currentTile = hit.transform.GetComponent<Tile>();
            currentTile.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

}
