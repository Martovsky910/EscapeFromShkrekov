using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    Projectile projectile;
    [SerializeField]
    float speed;
    void Awake()
    {
        Input.PlayerShoot += onShootPressed;
    }
    void onShootPressed()
    {
        var projGO = Instantiate(projectile.gameObject, gameObject.transform.position, gameObject.transform.rotation);
        projGO.GetComponent<Projectile>().Initialize(speed, gameObject, new HitData(25));
    }
}
