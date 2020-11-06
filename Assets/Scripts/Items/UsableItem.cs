using UnityEngine;

public class UsableItem : Item, IUsableItem
{
    public UsableItem(UsableItemTemplate template) : base(template) { }

    public UsableItemTemplate UsableTemplate => Template as UsableItemTemplate;

    public void Use()
    {
        if (UsableTemplate.ConsumedOnUse)
            ChangeStackAmount(-1);
        if (CurrentStacksAmount < 0)
            Debug.Log("У айтема стало стаков меньше нуля");
    }
}
