using UnityEngine;

public class InvComm_Use : InventoryCommand
{
    public string CommandName => "Использовать";
    Inventory inventory;
    Item Item;
    public InvComm_Use(Inventory inventory, Item Item)
    {
        this.inventory = inventory;
        this.Item = Item;
    }

    public bool CanBeExecuted()
    {
        return true;
    }

    public void Execute()
    {
        IUsableItem usableItem = Item as IUsableItem;
        usableItem.Use();
        if (Item.CurrentStacksAmount <= 0)
            inventory.RemoveItem(Item);
    }
}
