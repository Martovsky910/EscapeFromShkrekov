using UnityEngine;

public class InvComm_Use : InventoryCommand
{
    public string CommandName => "Использовать";
    Inventory inventory;
    UsableItem item;
    public InvComm_Use(Inventory inventory, Item item)
    {
        this.inventory = inventory;
        this.item = (UsableItem)item;
    }

    public bool CanBeExecuted()
    {
        return true;
    }

    public void Execute()
    {
        item.Use();
        if (item.ConsumedOnUse)
            item.ChangeAmount(-1);
        if (item.StacksAmount < 0)
            Debug.Log("У айтема стало стаков меньше нуля");
        if (item.StacksAmount <= 0)
            inventory.RemoveItem(item);
    }
}
