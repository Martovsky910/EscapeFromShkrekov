using System.Collections.Generic;
using UnityEngine;

public class NodeCreator : MonoBehaviour
{
    [SerializeField] Vector2 bottomLeftCorner;
    [SerializeField] Vector2 topRightCorner;
    [SerializeField] float cellSize;
    [SerializeField] LayerMask mask;
    [SerializeField] Transform EndNodePos;
    Node[,] map;
    void Awake()
    {
        map = CreateNodes();
    }

    public Node[,] CreateNodes()
    {
        Vector2 currentPos = bottomLeftCorner;
        List<Node> result = new List<Node>();
        Vector2Int totalAmount = GetRaycastAmount();
        int x = 0;
        int y = 0;
        while (x < totalAmount.x) //право
        {
            while (y < totalAmount.y)
            {
                currentPos = bottomLeftCorner + new Vector2(x * cellSize, y * cellSize);
                //Debug.Log($"currentPos [{currentPos}] x y [{x},{y}]");
                RaycastHit2D hit = Physics2D.BoxCast(currentPos, new Vector2(cellSize, cellSize),
                    0, Vector2.zero, Mathf.Infinity, mask);
                if (hit.collider == null)
                {
                    Debug.DrawLine(currentPos, currentPos + Vector2.up * 0.2f, Color.green, 100f);
                    result.Add(new Node(new Vector2Int(x, y), currentPos));
                }
                else
                {
                    Debug.DrawLine(currentPos, currentPos + Vector2.up * 0.2f, Color.red, 100f);
                }
                y++;
            }
            y = 0;
            x++;
        }
        Node[,] resultArray = new Node[totalAmount.x, totalAmount.y];
        foreach (Node node in result)
        {
            resultArray[node.Position.x, node.Position.y] = node;
        }
        return resultArray;
    }
    Vector2Int GetRaycastAmount()
    {
        Vector2 diff = new Vector2((topRightCorner.x - bottomLeftCorner.x) / cellSize,
            (topRightCorner.y - bottomLeftCorner.y) / cellSize);
        return new Vector2Int((int)diff.x + 1, (int)diff.y + 1);
    }
    void Update()
    {
        if (UnityEngine.Input.GetMouseButtonDown(1))
        {
            Vector3 objPos = EndNodePos.position;
            Vector2Int xy = GetXYByWorldPos(objPos);
            Debug.Log(objPos + " " + xy);
            Pathfinding p = new Pathfinding(map);
            List<Node> path = p.FindPath(new Vector2Int(0, 0), xy);
            if (path == null)
                Debug.Log("path null");
            else
                foreach (Node n in path)
                {
                    Debug.Log(n.RealWorldPos);
                    Debug.DrawLine(n.RealWorldPos, n.RealWorldPos + Vector3.up * 0.2f, Color.blue, 4f);
                }
        }
    }
    Vector2Int GetXYByWorldPos(Vector2 worldPos)
    {
        Vector2 diff = new Vector2((worldPos.x - bottomLeftCorner.x) / cellSize,
             (worldPos.y - bottomLeftCorner.y) / cellSize);
        return new Vector2Int((int)diff.x, (int)diff.y);
    }
}
