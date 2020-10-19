using System.Collections;
using UnityEngine;

public class FoV : MonoBehaviour
{
    Mesh mesh;
    float fov = 90f;
    int rayCount = 100;
    float angle = 0f;
    float viewDistance = 50f;
    float angleIncrease;
    [SerializeField] LayerMask mask;
    Coroutine updateFoVCoroutine;
    void Awake()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, 0f);
        angleIncrease = fov / rayCount;
        OnFogOfWarEnabledChange(InGameSettings.FogOfWarEnabled);
        InGameSettings.FogOfWarEnabledChanged += OnFogOfWarEnabledChange;
    }

    IEnumerator UpdateFov()
    {
        while (true)
        {
            Vector3[] verticies = new Vector3[rayCount + 2];
            Vector2[] uv = new Vector2[verticies.Length];
            int[] triangles = new int[rayCount * 3];
            angle = SetAimDirection(-Player.GO.transform.right);
            Vector3 origin = Player.PlayerPosition;
            verticies[0] = origin;

            int vertexIndex = 1;
            int triangleIndex = 0;
            for (int i = 0; i <= rayCount; i++)
            {
                Vector3 vertex;

                RaycastHit2D hit = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, mask);
                if (hit.collider == null)
                {
                    vertex = origin + GetVectorFromAngle(angle) * viewDistance;
                }
                else
                {
                    vertex = hit.point + (Vector2)GetVectorFromAngle(angle) * 0.3f;
                }
                verticies[vertexIndex] = vertex;
                if (i > 0)
                {
                    triangles[triangleIndex] = 0;
                    triangles[triangleIndex + 1] = vertexIndex - 1;
                    triangles[triangleIndex + 2] = vertexIndex;
                    triangleIndex += 3;
                }
                vertexIndex++;
                angle -= angleIncrease;
            }

            mesh.vertices = verticies;
            mesh.uv = uv;
            mesh.triangles = triangles;
            mesh.RecalculateBounds();
            yield return new WaitForEndOfFrame();
        }
    }
    void OnFogOfWarEnabledChange(bool isActive)
    {
        if (isActive)
        {
            if (updateFoVCoroutine != null)
            {
                //Debug.Log("корутина уже запущена, но так не должно быть");
                //TODO:разобраться
            }
            else
                updateFoVCoroutine = StartCoroutine(UpdateFov());
        }
        else
        {
            if (updateFoVCoroutine == null)
            {
                //Debug.Log("корутина уже остановлена, но так не должно быть");
                //TODO:разобраться
            }
            else
            {
                StopCoroutine(UpdateFov());
                updateFoVCoroutine = null;
            }
        }
    }
    Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
    float GetAngleFromVector(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
    float SetAimDirection(Vector3 dir)
    {
        return GetAngleFromVector(dir) - fov / 2f;
    }
}
