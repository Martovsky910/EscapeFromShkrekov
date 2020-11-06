using System.Collections.Generic;
using UnityEngine;

public static class NodeCreator
{
    static NodeCreatorSettings settings;
    public static Node[,] Map { get; private set; }
    public static void Initialize(NodeCreatorSettings setting)
    {
        settings = setting;
        Map = CreateNodes();
    }
    static Node[,] CreateNodes()
    {
        Vector2 currentPos;
        List<Node> result = new List<Node>();
        Vector2Int totalAmount = GetRaycastAmount();
        int x = 0;
        int y = 0;
        while (x < totalAmount.x)
        {
            while (y < totalAmount.y)
            {
                currentPos = settings.bottomLeftCorner + new Vector2(x * settings.cellSize, y * settings.cellSize);
                RaycastHit2D hit = Physics2D.BoxCast(currentPos, new Vector2(settings.cellSize, settings.cellSize),
                    0, Vector2.zero, Mathf.Infinity, settings.unwalkableLayers);
                if (hit.collider == null)
                {
                    if (settings.enableVisualDebug)
                        VisualDebug.DrawCross(currentPos, settings.cellSize * 0.5f, Color.green, 100f);
                    result.Add(new Node(new Vector2Int(x, y), currentPos));
                }
                else
                {
                    if (settings.enableVisualDebug)
                        VisualDebug.DrawCross(currentPos, settings.cellSize * 0.5f, Color.red, 100f);
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
    static Vector2Int GetRaycastAmount()
    {
        Vector2 diff = new Vector2((settings.topRightCorner.x - settings.bottomLeftCorner.x) / settings.cellSize,
            (settings.topRightCorner.y - settings.bottomLeftCorner.y) / settings.cellSize);
        return new Vector2Int((int)diff.x + 1, (int)diff.y + 1);
    }
    public static Vector2Int GetArrayPosByWorldPos(Vector2 worldPos)
    {
        Vector2 diff = new Vector2((worldPos.x - settings.bottomLeftCorner.x) / settings.cellSize,
             (worldPos.y - settings.bottomLeftCorner.y) / settings.cellSize);
        int xAddition = diff.x - (int)diff.x > 0.5f ? 1 : 0;
        int yAddition = diff.y - (int)diff.y > 0.5f ? 1 : 0;
        return new Vector2Int((int)diff.x, (int)diff.y) + new Vector2Int(xAddition, yAddition);
    }
}
