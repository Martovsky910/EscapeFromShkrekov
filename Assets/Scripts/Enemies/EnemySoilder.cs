using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoilder : MonoBehaviour, Damageble
{
    public static int EnemyIndex = 0;
    [SerializeField] int maxHealth;
    [SerializeField] LayerMask mask;
    [SerializeField] GameObject target;
    [SerializeField] float maxSpeed;
    [SerializeField] float maxRotationAngle;
    public Projectile projectile;
    public float projectileSpeed;
    int currentHealth;
    EnemyState currentState;
    EnemyDebugger debugger;
    public FoVRaycaster FoV { get; private set; }
    public List<Waypoint> wayPoints;
    public Rigidbody2D Rb { get; private set; }
    public float CurrentMovespeed { get; private set; }
    public string EnemyName => $"Enemy {EnemyIndex}";
    public float MaxRotationAngle => maxRotationAngle; 

    void Awake()
    {
        debugger = GetComponent<EnemyDebugger>();
        EnemyIndex++;
        gameObject.name = EnemyName;
        Rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        CurrentMovespeed = maxSpeed;
    }
    void Start()
    {
        currentState = new EnemyStateRoam(this, debugger);
        FoV = new FoVRaycaster(transform, 50, 100, 50, gameObject, mask);
    }
    public void TakeHit(HitData data)
    {
        Debug.Log("Получил урон " + data.Damage);
        currentHealth -= data.Damage;
        if (currentHealth < 0)
            Destroy(gameObject);
    }
    public void ChangeState(EnemyState newState)
    {
        currentState = newState;
    }
    void FixedUpdate()
    {
        currentState.OnUpdate();
    }

}



