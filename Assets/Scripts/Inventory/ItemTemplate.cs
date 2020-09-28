using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemTemplate : ScriptableObject
{
    [SerializeField]
    Sprite sprite;
    [SerializeField]
    int amountOfSlotsOccuoied;
    [SerializeField]
    string itemName;
    public Sprite Sprite => sprite;
    public int AmountOfSlotsOccuoied => amountOfSlotsOccuoied;
    public string ItemName => itemName;
}
