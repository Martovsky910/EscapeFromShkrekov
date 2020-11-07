using System;
using UnityEngine;

public static class ItemsOnPlayer
{
    public static event Action EquipmentChanged;
    public static Inventory PlayerInventory { get; private set; }
    public static Item Weapon { get; private set; }
    public static void SetInventory(Inventory inventory, Item weapon)
    {
        PlayerInventory = inventory;
        Weapon = weapon;
    }
    public static void ChangeWeapon(Item newWeapon)
    {
        PlayerInventory.AddItem(Weapon);
        //TODO: дропать старое оружее если нет места в инвентаре
        Weapon = newWeapon;
        EquipmentChanged?.Invoke();
    }
}
