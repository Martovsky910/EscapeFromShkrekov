using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EnemySoilder))]
public class EnemyDebugger : MonoBehaviour
{
    EnemySoilder debugTarget;
    [SerializeField] bool enablePathDebug;
    [SerializeField] float pathVisibleDuration;
    [SerializeField] Color pathColor;
    [SerializeField] float waypointVisibleDuration;
    [SerializeField] Color waypointColor;
    EnemySoilder DebugTarget
    {
        get
        {
            if (debugTarget == null)
                debugTarget = GetComponent<EnemySoilder>();
            return debugTarget;
        }
    }

    [ContextMenu("Показать вейпоинты")]
    void ShowWaypoints()
    {
        foreach (Waypoint waypoint in DebugTarget.wayPoints)
        {
            VisualDebug.DrawCross(waypoint.Position, 0.5f, waypointColor, waypointVisibleDuration);
        }
    }
    public void OnPathChange(List<Node> path)
    {
        if (!enablePathDebug || path == null) return;

        Node prevNode = null;
        foreach (Node node in path)
        {
            VisualDebug.DrawCross(node.RealWorldPos, 0.5f, pathColor, pathVisibleDuration);
            if (prevNode != null)
                Debug.DrawLine(prevNode.RealWorldPos, node.RealWorldPos, pathColor, pathVisibleDuration);
            prevNode = node;
        }
    }
    public void OnNoPathAvaliable(EnemySoilder entity, Waypoint waypoint)
    {
        Debug.Log($"{entity.EnemyName} не смог построить путь до {waypoint.WaypointName} [{waypoint.Position}]");
    }
}
