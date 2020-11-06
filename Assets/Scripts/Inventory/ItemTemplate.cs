using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemTemplate : ScriptableObject
{
    [SerializeField]
    Sprite sprite;
    [SerializeField]
    Sprite worldSprite;
    [SerializeField]
    Vector3 worldSize;
    [SerializeField]
    int amountOfSlotsOccuoied;
    [SerializeField]
    string itemName;
    [SerializeField]
    int maxStackAmount;
    public Sprite Sprite => sprite;
    public int AmountOfSlotsOccuoied => amountOfSlotsOccuoied;
    public string ItemName => itemName;
    public Sprite WorldSprite => worldSprite;
    public Vector3 WorldSize => worldSize;
    public int MaxStackAmount => maxStackAmount;

    public virtual Item CreateInstance()
    {
        return new Item(this);
    }
}
