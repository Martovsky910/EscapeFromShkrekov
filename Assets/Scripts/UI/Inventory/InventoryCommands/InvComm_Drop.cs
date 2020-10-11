using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvComm_Drop : InventoryCommand
{
    public string CommandName => "Выбросить";
    Inventory inventory;
    Item item;
    public InvComm_Drop(Inventory inventory, Item item)
    {
        this.inventory = inventory;
        this.item = item;
    }

    public void Execute()
    {
        inventory.RemoveItem(item);
    }

    public bool CanBeExecuted() => true;
}
