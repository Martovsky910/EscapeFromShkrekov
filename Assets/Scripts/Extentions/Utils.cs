using System;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static float LookAt(Transform from, Vector3 to, float maximum)
    {
        float currentAngle = from.transform.eulerAngles.z;
        Vector3 direction = (from.position - to).normalized;
        float finalAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        if (finalAngle < 0) finalAngle += 360;
        if (finalAngle >= 360) finalAngle -= 360;
        if (Math.Abs(currentAngle - finalAngle) > maximum)
        {
            if (finalAngle < currentAngle)
            {
                if (Math.Abs(finalAngle - currentAngle) > 180)
                    finalAngle = currentAngle + maximum;
                else
                    finalAngle = currentAngle - maximum;
            }
            else
            {

                if (Math.Abs(finalAngle - currentAngle) <= 180)
                    finalAngle = currentAngle + maximum;
                else
                    finalAngle = currentAngle - maximum;
            }
        }
        return finalAngle;
    }
    public static float GetAgleByVector(Vector3 from, Vector3 to)
    {
        Vector3 direction = (from - to).normalized;
        float finalAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        if (finalAngle < 0) finalAngle += 360;
        if (finalAngle >= 360) finalAngle -= 360;
        return finalAngle;
    }
}
