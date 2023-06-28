public interface ICoordinateMoveable
{
    public Tile currentTile { get; set; }

    public void XCoorIncrement(int x);
    public void YCoorIncrement(int y);
    public void ZCoorIncrement(int z);
}

