using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    GameObject buttonPrefab;
    List<GameObject> buttons = new List<GameObject>();
    public void Initialize()
    {
        ItemsOnPlayer.PlayerInventory.InventoryChanged += OnInventoryChanged;
        Input.InventoryModeChangedTo += OnInventoryOpenClose;
        OnInventoryChanged();
        gameObject.SetActive(false);
    }
    void OnInventoryOpenClose(bool status)
    {
        gameObject.SetActive(status);
    }
    void OnInventoryChanged()
    {
        buttons.ForEach(b => Destroy(b));
        buttons = new List<GameObject>();
        foreach (Item item in ItemsOnPlayer.PlayerInventory.Items)
        {
            var button = Instantiate(buttonPrefab, transform);
            button.GetComponent<InventoryButton>().Initialize(item, ItemsOnPlayer.PlayerInventory);
            buttons.Add(button);
        }
    }
}
