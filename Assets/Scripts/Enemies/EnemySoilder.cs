using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngineInternal;

public class EnemySoilder : MonoBehaviour, Damageble
{
    [SerializeField] int maxHealth;
    [SerializeField] LayerMask mask;
    [SerializeField] GameObject target;
    int currentHealth;
    int rayCount = 100;
    int fov = 100;
    float viewDistance = 50f;
    float angleIncrease;
    void Awake()
    {
        angleIncrease = fov / rayCount;
        currentHealth = maxHealth;
        StartCoroutine(fieldofview());
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

    IEnumerator fieldofview()
    {
        while (true)
        {
            Vector3 origin = transform.position;
            float angle = SetAimDirection(-transform.right);
            for (int i = 0; i <= rayCount; i++)
            {
                RaycastHit2D[] hits = Physics2D.RaycastAll(origin, GetVectorFromAngle(angle), viewDistance, mask);
                bool targetFound = false;
                foreach (RaycastHit2D hit in hits)
                {
                    if (hit.collider.gameObject == gameObject)
                        continue;
                    Color c = Color.green;

                    if (hit.collider.gameObject == target)
                    {
                        c = Color.red;
                        //Debug.Log("нашел таргет");
                    }

                    Debug.DrawLine(origin, hit.point, c, 0.3f);
                    targetFound = true;
                    break;
                }

                if (!targetFound)
                    Debug.DrawLine(origin, origin + GetVectorFromAngle(angle) * viewDistance, Color.green, 0.3f);
                angle -= angleIncrease;
            }
            yield return new WaitForSecondsRealtime(0.3f);
        }

    }
    Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
    float SetAimDirection(Vector3 dir)
    {
        return GetAngleFromVector(dir) - fov / 2f;
    }
    float GetAngleFromVector(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
}
