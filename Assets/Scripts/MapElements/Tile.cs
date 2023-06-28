using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, ISelectable
{
    public int xCoordinate;
    public int zCoordinate;

    MeshRenderer mesh => GetComponent<MeshRenderer>();
    public void Deselect()
    {
        mesh.material.color = Color.green;
    }

    public void Select()
    {
        mesh.material.color = Color.red;
    }
}
