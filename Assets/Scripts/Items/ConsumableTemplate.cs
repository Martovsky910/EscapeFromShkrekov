using UnityEngine;
[CreateAssetMenu(fileName = "new consumable", menuName = "Consumable")]
public class ConsumableTemplate : UsableItemTemplate
{
    public override Item CreateItemFromTemplate()
    {
        return new Consumable(this);
    }
}
