
public class Item
{
    public ItemTemplate Template { get; protected set; }
    public int CurrentStacksAmount { get; protected set; }
    public Item(ItemTemplate template)
    {
        Template = template;
    }
    public void ChangeStackAmount(int howMuch)
    {
        CurrentStacksAmount += howMuch;
    }
}
