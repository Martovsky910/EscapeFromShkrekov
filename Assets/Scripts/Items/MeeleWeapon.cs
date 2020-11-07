using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleWeapon : Item, IWeapon, IEqipable
{
    public MeeleWeapon(MeeleWeaponTemplate template) : base(template) { }

    public EquipmentSlot Slot => EquipmentSlot.Weapon;

    public void Attack()
    {
        Debug.Log("Атаковал");
    }
}
