using UnityEngine;

public class ItemsOnPlayer
{
    public static Inventory PlayerInventory { get; private set; }
    static ItemsOnPlayer()
    {
        PlayerInventory = new Inventory(10);
    }
}
