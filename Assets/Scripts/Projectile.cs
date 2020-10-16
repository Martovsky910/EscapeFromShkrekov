using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float speed;
    Coroutine moveRoutine;
    BoxCollider2D collider;
    GameObject caster;
    HitData hitData;
    public void Initialize(float speed, GameObject caster, HitData hitData)
    {
        this.speed = speed;
        this.caster = caster;
        this.hitData = hitData;
        collider = GetComponent<BoxCollider2D>();
        moveRoutine = StartCoroutine(move());
    }
    IEnumerator move()
    {
        while (true)
        {
            RaycastHit2D[] result = new RaycastHit2D[10];
            if (collider.Cast(Vector2.zero, result) > 0 && result[0].collider.gameObject != caster)
            {
                Debug.Log("Врезался в " + result[0].collider.gameObject.name);
                Damageble damageble = result[0].collider.gameObject.GetComponent<Damageble>();
                if (damageble != null)
                {
                    damageble.TakeHit(hitData);
                }
                    destroyBullet();
            }
            else
            {
                Vector3 additional = gameObject.transform.up * speed;
                gameObject.transform.position += additional;
            }
            yield return new WaitForEndOfFrame();
        }
    }
    void destroyBullet()
    {
        if (moveRoutine != null)
            StopCoroutine(moveRoutine);
        Destroy(gameObject);
    }
}