using System;
[Serializable]
public class Item
{
    public ItemTemplate ItemTemplate { get; private set; }
    public int StacksAmount { get; private set; }
    public Item(ItemTemplate template)
    {
        ItemTemplate = template;
    }
    public void ChangeAmount(int howMuch)
    {
        StacksAmount += howMuch;
    }
}
