using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    Node[,] map;
    const int move_str_cost = 10;
    const int move_diag_cost = 14;
    public Pathfinding()
    {
        this.map = new Node[NodeCreator.Map.GetLength(0), NodeCreator.Map.GetLength(1)];
        foreach (Node node in NodeCreator.Map)
        {
            if (node != null)
                this.map[node.Position.x, node.Position.y] = node.Clone();
        }
    }
    public List<Node> FindPath(Vector3 start, Vector3 end)
    {
        //позиции в map
        Vector2Int startNodeArrayPos = NodeCreator.GetArrayPosByWorldPos(start);
        Vector2Int endNodeArrayPos = NodeCreator.GetArrayPosByWorldPos(end);

        return FindPath(startNodeArrayPos, endNodeArrayPos);
    }
    public List<Node> FindPath(Vector2Int start, Vector2Int end)
    {
        Node startNode = map[start.x, start.y];
        Node endNode = map[end.x, end.y];
        if (startNode == null)
        {
            Debug.Log("start node null");
            return null;
        }
        if (endNode == null)
        {
            Debug.Log("end node null");
            return null;
        }
        List<Node> openList = new List<Node> { startNode };
        List<Node> closedList = new List<Node>();
        startNode.gCost = 0;
        startNode.hCost = CalculateDistance(startNode, endNode);
        while (openList.Count > 0)
        {
            Node currentNode = FindLowestFCost(openList);
            if (currentNode == endNode)
            {
                return RetracePath(endNode);
            }
            openList.Remove(currentNode);
            closedList.Add(currentNode);

            foreach (Node neighbour in GetNeighbours(currentNode, map))
            {
                if (closedList.Contains(neighbour)) continue;
                int tentativeG = currentNode.gCost + CalculateDistance(currentNode, neighbour);
                if (tentativeG < neighbour.gCost)
                {
                    neighbour.CameFrom = currentNode;
                    neighbour.gCost = tentativeG;
                    neighbour.hCost = CalculateDistance(neighbour, endNode);
                    if (!openList.Contains(neighbour))
                        openList.Add(neighbour);
                }
            }
        }
        return null;
    }
    int CalculateDistance(Node a, Node b)
    {
        int xDist = Mathf.Abs(a.Position.x - b.Position.x);
        int yDist = Mathf.Abs(a.Position.y - b.Position.y);
        int remaining = Mathf.Abs(xDist - yDist);
        return move_diag_cost * Mathf.Min(xDist, yDist) + move_str_cost * remaining;
    }
    Node FindLowestFCost(List<Node> nodes)
    {
        Node lowest = nodes[0];
        for (int i = 0; i < nodes.Count; i++)
        {
            if (lowest.fCost > nodes[i].fCost)
                lowest = nodes[i];
        }
        return lowest;
    }
    List<Node> GetNeighbours(Node node, Node[,] map)//TODO: везде стоит GetLenght(0)
    {
        List<Node> result = new List<Node>();
        if (node.Position.x - 1 >= 0)
        {
            Node item = map[node.Position.x - 1, node.Position.y];
            if (item != null)
                result.Add(item);
        }
        if (node.Position.x + 1 < map.GetLength(0))
        {
            Node item = map[node.Position.x + 1, node.Position.y];
            if (item != null)
                result.Add(item);
        }
        if (node.Position.y - 1 >= 0)
        {
            Node item = map[node.Position.x, node.Position.y - 1];
            if (item != null)
                result.Add(item);
        }

        if (node.Position.y + 1 < map.GetLength(0))
        {
            Node item = map[node.Position.x, node.Position.y + 1];
            if (item != null)
                result.Add(item);
        }

        if (node.Position.x - 1 >= 0 && node.Position.y + 1 < map.GetLength(0))
        {
            Node item = map[node.Position.x - 1, node.Position.y + 1];
            if (item != null)
                result.Add(item);
        }
        if (node.Position.x + 1 < map.GetLength(0) && node.Position.y + 1 < map.GetLength(0))
        {
            Node item = map[node.Position.x + 1, node.Position.y + 1];
            if (item != null)
                result.Add(item);
        }
        if (node.Position.x - 1 >= 0 && node.Position.y - 1 >= 0)
        {
            Node item = map[node.Position.x - 1, node.Position.y - 1];
            if (item != null)
                result.Add(item);
        }
        if (node.Position.x + 1 < map.GetLength(0) && node.Position.y - 1 >= 0)
        {
            Node item = map[node.Position.x + 1, node.Position.y - 1];
            if (item != null)
                result.Add(item);
        }
        return result;
    }
    List<Node> RetracePath(Node endNode)
    {
        List<Node> result = new List<Node>();
        result.Add(map[endNode.Position.x, endNode.Position.y]);
        Node current = endNode;
        while (current.CameFrom != null)
        {
            result.Add(map[current.CameFrom.Position.x, current.CameFrom.Position.y]);
            current = current.CameFrom;
        }
        result.Reverse();
        return result;
    }
}

