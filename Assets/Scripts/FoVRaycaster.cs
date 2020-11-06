using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FoVRaycaster
{
    int rayCount;
    int fov;
    float viewDistance;
    float angleIncrease;
    GameObject self;
    LayerMask mask;
    Transform owner;
    public FoVRaycaster(Transform owner,int rayCount, int fov, int viewDistance, GameObject self, LayerMask mask)
    {
        this.owner = owner;
        this.rayCount = rayCount;
        this.fov = fov;
        this.viewDistance = viewDistance;
        this.self = self;
        this.mask = mask;
        angleIncrease = fov / rayCount;
    }
    public bool FindPlayer(bool showLines = false)
    {
        return Find(Player.GO, showLines);
    }
    public bool Find(GameObject target, bool showLines = false)
    {
        if (target == null || owner == null)
            return false;

        bool result = false;

        Vector3 origin = owner.position;
        float angle = SetAimDirection(-owner.right);

        for (int i = 0; i <= rayCount; i++)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(origin, Vector3Ext.GetVectorFromAngle(angle), viewDistance, mask);
            if (hits.Any())
                foreach (RaycastHit2D hit in hits)
                {
                    if (hit.collider.gameObject == self)
                        continue;
                    Color c = Color.green;

                    if (target != null && hit.collider.gameObject == target)
                    {
                        c = Color.red;
                        result = true;
                    }

                    if (showLines)
                        Debug.DrawLine(origin, hit.point, c, Time.deltaTime);
                    break;
                }
            else if (showLines)
                Debug.DrawLine(origin, origin + Vector3Ext.GetVectorFromAngle(angle) * viewDistance, Color.green, Time.deltaTime);
            angle -= angleIncrease;
        }
        return result;
    }
    public float SetAimDirection(Vector3 dir)
    {
        return Vector3Ext.GetAngleFromVector(dir) - fov / 2f;
    }
}