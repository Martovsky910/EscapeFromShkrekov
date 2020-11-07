using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyStateCombat : EnemyState
{
    int cooldown = 3;
    float cooldownLeft = 0;
    float outOfCombatTime = 0;
    const int outOfCombatMaxTime = 5;
    Coroutine cooldownCour;
    public EnemyStateCombat(EnemySoilder owner, EnemyDebugger debugger) : base(owner, debugger)
    {
    }
    public override void OnUpdate()
    {
        DecreaseShootCooldown();
        if (owner.FoV.FindPlayer(false))
        {
            outOfCombatTime = 0;
            float angleToPlayer = Utils.LookAt(owner.transform, Player.PlayerPosition, owner.MaxRotationAngle);
            bool lookingAtPlayer = Math.Abs(angleToPlayer - Utils.GetAgleByVector(owner.transform.position, Player.PlayerPosition)) < 0.1f;
            if (lookingAtPlayer)
            {
                Shoot();
            }
            else
            {
                owner.Rb.MoveRotation(angleToPlayer);
            }
        }
        else
        {
            outOfCombatTime += Time.fixedDeltaTime;
            if (outOfCombatTime > outOfCombatMaxTime)
                owner.ChangeState(new EnemyStateRoam(owner, debugger));
        }
    }
    void Shoot()
    {
        if (cooldownLeft > 0) return;
        //Debug.Log("Pew!");
        Debug.DrawLine(owner.transform.position, Player.PlayerPosition, Color.blue, 0.5f);
        var projGO = GameObject.Instantiate(owner.projectile.gameObject, owner.transform.position, owner.transform.rotation);
        projGO.GetComponent<Projectile>().Initialize(owner.projectileSpeed, owner.gameObject, new HitData(25));
        cooldownLeft = cooldown;
    }
    void DecreaseShootCooldown()
    {
        if (cooldownLeft > 0)
        {
            cooldownLeft -= Time.fixedDeltaTime;
        }
    }
}
