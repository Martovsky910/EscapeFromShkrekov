using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    Inventory inventory;
    Item item;
    [SerializeField]
    Inv_ContextMenu rbm_menu;
    public static Action<Item, Inventory> OnMouseRightClick;

    public void Initialize(Item item, Inventory inventory)
    {
        GetComponent<Image>().sprite = item.Template.Sprite;
        this.item = item;
        this.inventory = inventory;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            OnLMB();
        else if (eventData.button == PointerEventData.InputButton.Right)
            OnRBM();
    }
    void OnLMB()
    {
        Debug.Log("Кликнул на " + item.Template.ItemName);

    }
    void OnRBM()
    {
        OnMouseRightClick?.Invoke(item, inventory);
    }
}
