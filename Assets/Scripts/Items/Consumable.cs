using UnityEngine;
public class Consumable : UsableItem
{
    public Consumable(ConsumableTemplate template) : base(template)
    {
    }
    public override void Use()
    {
        Player.Properties.ChangeHealth(10);
    }
}
