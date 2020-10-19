using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class EnemySoilder : MonoBehaviour, Damageble
{
    [SerializeField] int maxHealth;
    [SerializeField] LayerMask mask;
    [SerializeField] GameObject target;
    [SerializeField] List<Waypoint> wayPoints;
    [SerializeField] float MaxSpeed;
    [SerializeField] bool debugShowPath;
    FoVRaycaster raycaster;
    int currentHealth;
    Rigidbody2D rb;

    Waypoint currentWaypoint;
    List<Node> currentPath;
    int currentNodeIndex = 0;
    int currentWaypointIndex = 0;
    void Start()
    {
        showDebugPath();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        raycaster = new FoVRaycaster(100, 100, 50, gameObject, mask);
        //StartCoroutine(fieldofview());
        if (wayPoints.Any())
        {
            currentWaypoint = wayPoints.First();
        }
    }
    public void Initialize()
    {
    }
    public void TakeHit(HitData data)
    {
        Debug.Log("Получил урон " + data.Damage);
        currentHealth -= data.Damage;
        if (currentHealth < 0)
            Destroy(gameObject);
    }
    void FixedUpdate()
    {
        updateMove();
    }
    IEnumerator fieldofview()
    {
        while (true)
        {
            if (raycaster.Find(transform, Player.GO, true))
            {
                Vector3 direction = (Player.PlayerPosition - transform.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
                rb.MoveRotation(angle);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    void updateMove()
    {
        if (currentPath == null)
        {
            Pathfinding p = new Pathfinding();
            currentPath = p.FindPath(transform.position, currentWaypoint.Position);
            if (currentPath == null)
            {
                Debug.Log("не смог найти путь");
                return;
            }
            else
                Debug.Log("получил путь длинной " + currentPath.Count);
        }
        //Debug.Log("иду к ноде " + currentNodeIndex);
        // Debug.Log("Осталось пройти " + Vector3.Distance(transform.position, currentPath[currentNodeIndex].RealWorldPos));
        if (Vector3.Distance(transform.position, currentPath[currentNodeIndex].RealWorldPos) > 0.1f)
        {
            Vector3 nextPos = Vector3.MoveTowards(transform.position, currentPath[currentNodeIndex].RealWorldPos, MaxSpeed);
            rb.MovePosition(nextPos);
        }
        else
        {
            //Debug.Log("перехожу на следующую ноду");
            if (currentNodeIndex + 1 < currentPath.Count)
                currentNodeIndex++;
            else
            {
                //Debug.Log("Перехожу на следующий вейпоинт");
                currentNodeIndex = 0;
                currentPath = null;
                if (currentWaypointIndex + 1 < wayPoints.Count)
                {
                    currentWaypointIndex++;
                }
                else
                    currentWaypointIndex = 0;
                currentWaypoint = wayPoints[currentWaypointIndex];
            }
        }
    }


    void showDebugPath()
    {
        if (wayPoints.Any() && debugShowPath)
        {
            Waypoint prev = null;
            foreach (Waypoint waypoint in wayPoints)
            {
                VisualDebug.DrawCross(waypoint.Position, 0.5f, Color.green, 1000f);
                if (prev != null)
                {
                    Pathfinding p = new Pathfinding();
                    List<Node> path = p.FindPath(prev.Position, waypoint.Position);
                    Node prevNode = null;
                    foreach (Node node in path)
                    {
                        VisualDebug.DrawCross(node.RealWorldPos, 0.5f, Color.red, 1000f);
                        //if (prevNode != null)
                        //    Debug.DrawLine(prevNode.RealWorldPos, node.RealWorldPos, Color.magenta, 1000f);
                        prevNode = node;
                    }
                }
                prev = waypoint;
            }

            Pathfinding p2 = new Pathfinding();
            List<Node> backToStartPath = p2.FindPath(wayPoints.Last().Position, wayPoints.First().Position);
            Node prevNodeBackToStart = null;
            foreach (Node node in backToStartPath)
            {
                VisualDebug.DrawCross(node.RealWorldPos, 0.5f, Color.red, 1000f);
                //if (prevNode != null)
                //    Debug.DrawLine(prevNode.RealWorldPos, node.RealWorldPos, Color.magenta, 1000f);
                prevNodeBackToStart = node;
            }
        }
    }

}



