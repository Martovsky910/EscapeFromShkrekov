using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event Action InventoryChanged;
    public List<ItemTemplate> Items { get; private set; }
    public int Size { get; protected set; }
    public int FilledSlots { get; protected set; } = 0;
    public Inventory(int size)
    {
        Size = size;
        Items = new List<ItemTemplate>();
    }
    public bool AddItem(ItemTemplate item)
    {
        bool result = false;
        if (FilledSlots + item.AmountOfSlotsOccuoied < Size)
        {
            FilledSlots += item.AmountOfSlotsOccuoied;
            Items.Add(item);
            result = true;
            InventoryChanged?.Invoke();
            Debug.Log("Добавил предмет в инвентарь " + item.ItemName);
        }
        return result;
    }
}
