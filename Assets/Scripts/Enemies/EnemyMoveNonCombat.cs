using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMoveNonCombat
{
    const float minDistance = 0.05f;
    const float maxRotationAngle = 7f;
    EnemySoilder owner;
    List<Node> currentPath;
    Action onTargetReach;
    Vector3 OwnerPos => owner.transform.position;
    public EnemyMoveNonCombat(EnemySoilder owner, Vector3 target, Action onTargetReach, Action<List<Node>> onPathCreated)
    {
        this.owner = owner;
        this.onTargetReach = onTargetReach;
        //Debug.Log($"ownerPos {OwnerPos}, target {target}");
        Pathfinding.FindPath(OwnerPos, target, out currentPath);

        //Debug.Log($"первая точка {currentPath.First().RealWorldPos}");
        onPathCreated(currentPath);
        // Debug.Log("задал новый вейпоинт, путь " + currentPath.Count);
    }
    public void Move()
    {
        //Debug.Log("Было " + currentPath.Count + " нод перед движением");
        if (currentPath.Count == 0)
        {
            onTargetReach();
            return;
        }
        if (reachedNode(currentPath[0]))
        {
            // Debug.Log("удалил ноду");
            currentPath.RemoveAt(0);
            return;
        }

        float angleToLook = Utils.LookAt(owner.transform, currentPath[0].RealWorldPos, maxRotationAngle);
        if (Math.Abs(owner.transform.eulerAngles.z - angleToLook) <= maxRotationAngle)
        {
            Vector3 nextPos = Vector3.MoveTowards(OwnerPos, currentPath[0].RealWorldPos, owner.CurrentMovespeed);
            owner.Rb.MovePosition(nextPos);
        }
        owner.Rb.MoveRotation(angleToLook);
    }
   
    bool reachedNode(Node node)
    {
        float distance = Vector3.Distance(OwnerPos, node.RealWorldPos);
        return distance < minDistance;
    }
}
