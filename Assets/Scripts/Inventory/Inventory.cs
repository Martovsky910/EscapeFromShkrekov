using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event Action InventoryChanged;
    public List<Item> Items { get; private set; }
    public int Size { get; protected set; }
    public int FilledSlots { get; protected set; } = 0;
    public Inventory(int size)
    {
        Size = size;
        Items = new List<Item>();
    }
    public bool AddItem(Item item)
    {
        bool result = false;
        if (FilledSlots + item.ItemTemplate.AmountOfSlotsOccuoied < Size)
        {
            FilledSlots += item.ItemTemplate.AmountOfSlotsOccuoied;
            Items.Add(item);
            result = true;
            InventoryChanged?.Invoke();
            Debug.Log("Добавил предмет в инвентарь " + item.ItemTemplate.ItemName);
        }
        return result;
    }
    public void RemoveItem(Item item)
    {
        Items.Remove(item);
        FilledSlots -= item.ItemTemplate.AmountOfSlotsOccuoied;
        InventoryChanged?.Invoke();
        Debug.Log("Убрал предмет из инвентаря " + item.ItemTemplate.ItemName);
    }
}
