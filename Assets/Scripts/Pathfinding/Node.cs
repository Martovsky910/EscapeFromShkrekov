using UnityEngine;

public class Node
{
    public int gCost = int.MaxValue;
    public int hCost;
    public int fCost => gCost + hCost;

    public Vector2Int Position;
    public Vector3 RealWorldPos;
    public Node CameFrom;
    public Node(Vector2Int position, Vector3 realWorldPos)
    {
        Position = position;
        RealWorldPos = realWorldPos;
    }
    public Node Clone()
    {
        return new Node(Position, RealWorldPos);
    }
}
