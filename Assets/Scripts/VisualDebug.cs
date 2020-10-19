using System.Collections.Generic;
using UnityEngine;

public class VisualDebug
{
    public static void DrawPath(List<Node> nodes, Color color, float time)
    {
        if (nodes == null) return;
        Node prevNode = null;
        foreach (Node node in nodes)
        {
            if (prevNode != null)
            {
                Debug.DrawLine(prevNode.RealWorldPos, node.RealWorldPos, color, time);
            }
            prevNode = node;
        }
    }
    public static void DrawCross(Vector2 pos, float size, Color color, float time)
    {
        Debug.DrawLine(pos, pos + Vector2.up * size, color, time);
        Debug.DrawLine(pos, pos + Vector2.right * size, color, time);
        Debug.DrawLine(pos, pos + Vector2.down * size, color, time);
        Debug.DrawLine(pos, pos + Vector2.left * size, color, time);
    }
}
