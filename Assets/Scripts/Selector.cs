using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    Tile m_currentTile => MovementHandler.currentTile;

    [SerializeField]
    Object m_movementHandler;
    ICoordinateMoveable MovementHandler => m_movementHandler as ICoordinateMoveable;

    public void MoveXCoor(int x)
    {
        MovementHandler.XCoorIncrement(x);
    }

    public void MoveZCoor(int z)
    {
        MovementHandler.ZCoorIncrement(z);
    }
}
