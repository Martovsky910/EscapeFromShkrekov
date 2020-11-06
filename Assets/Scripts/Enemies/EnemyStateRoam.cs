using System.Collections.Generic;
using UnityEngine;

public class EnemyStateRoam : EnemyState
{
    EnemyMoveNonCombat move;
    Waypoint currentWaypoint;
    public EnemyStateRoam(EnemySoilder owner, EnemyDebugger debugger) : base(owner, debugger)
    {
        currentWaypoint = FindClosestWaypoint();
        move = new EnemyMoveNonCombat(owner, currentWaypoint.Position, OnMoveTargetReached, OnPathCreated);
    }
    public override void OnUpdate()
    {
        if (owner.FoV.FindPlayer(true))
        {
            EnemyStateCombat newState = new EnemyStateCombat(owner, debugger);
            owner.ChangeState(newState);
            return;
        }
        move.Move();
    }
    Waypoint FindClosestWaypoint()
    {
        float minDistance = float.MaxValue;
        Waypoint result = null;
        foreach (Waypoint waypoint in owner.wayPoints)
        {
            if (Vector3.Distance(waypoint.Position, owner.transform.position) < minDistance)
                result = waypoint;
        }
        return result;
    }
    void OnMoveTargetReached()
    {
        currentWaypoint = GetNextWaypoint();
        move = CreateNewMoveInstance();
    }
    Waypoint GetNextWaypoint()
    {
        int index = owner.wayPoints.IndexOf(currentWaypoint);

        if (index + 1 == owner.wayPoints.Count)
            return owner.wayPoints[0];
        else
            return owner.wayPoints[index + 1];
    }
    void OnPathCreated(List<Node> path)
    {
        debugger?.OnPathChange(path);
        if (path.Count == 0)
        {
            debugger?.OnNoPathAvaliable(owner, currentWaypoint);
            OnMoveTargetReached();
        }
    }
    EnemyMoveNonCombat CreateNewMoveInstance() => new EnemyMoveNonCombat
        (owner, currentWaypoint.Position, OnMoveTargetReached, OnPathCreated);
}
