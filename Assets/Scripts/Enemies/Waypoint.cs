using UnityEngine;
[System.Serializable]
public class Waypoint
{
    [SerializeField] Transform WayPointTransform;
    [SerializeField] float angleToLook;
    [SerializeField] float stayTime;
    [SerializeField] string name;
    public Vector3 Position => WayPointTransform.position;
    public float AngleToLook => angleToLook;
    public float StayTime => stayTime;
    public string WaypointName => name;
}
