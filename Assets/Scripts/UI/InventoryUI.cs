using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    GameObject buttonPrefab;
    List<GameObject> buttons = new List<GameObject>();
    void Awake()
    {
        ItemsOnPlayer.PlayerInventory.InventoryChanged += OnInventoryChanged;
    }

    void OnInventoryChanged()
    {
        buttons.ForEach(b => Destroy(b));
        buttons = new List<GameObject>();
        foreach (var item in ItemsOnPlayer.PlayerInventory.Items)
        {
            var button = Instantiate(buttonPrefab, transform);
            button.GetComponent<InventoryButton>().Initialize(item);
            buttons.Add(button);
        }
    }
}
