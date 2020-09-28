using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    ItemTemplate item;
    public void Initialize(ItemTemplate item)
    {
        GetComponent<Image>().sprite = item.Sprite;
        this.item = item;
    }
    public void Onclick()
    {
        Debug.Log("Кликнул на " + item.ItemName);
    }
}
