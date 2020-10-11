using UnityEngine;

public class UsableItemTemplate : ItemTemplate
{
    [SerializeField]
    bool consumedOnUse;
    public bool ConsumedOnUse => consumedOnUse;
}
