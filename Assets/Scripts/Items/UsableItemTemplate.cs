using UnityEngine;
[CreateAssetMenu(fileName = "new usable item", menuName = "Usable item")]
public class UsableItemTemplate : ItemTemplate
{
    [SerializeField]
    bool consumedOnUse;
    public bool ConsumedOnUse => consumedOnUse;
    public override Item CreateInstance()
    {
        return new UsableItem(this);
    }
}
