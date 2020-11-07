public class InvComm_Equip : InventoryCommand
{
    Inventory inventory;
    Item item;
    public string CommandName => "Надеть";

    public InvComm_Equip(Inventory inventory, Item item)
    {
        this.inventory = inventory;
        this.item = item;
    }
    public bool CanBeExecuted() => true;

    public void Execute()
    {
        ItemsOnPlayer.ChangeWeapon(item);
        inventory.RemoveItem(item);
    }
}
