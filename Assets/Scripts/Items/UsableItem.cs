public abstract class UsableItem : Item
{
    public bool ConsumedOnUse { get; private set; }
    public UsableItem(UsableItemTemplate template) : base(template) 
    {
        ConsumedOnUse = template.ConsumedOnUse;
    }
    public abstract void Use();
}
