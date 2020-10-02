using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Item
{
    public ItemTemplate ItemTemplate { get; private set; }
    public int Amount { get; private set; } = 1;
    public Item(ItemTemplate template)
    {
        ItemTemplate = template;
    }
}
