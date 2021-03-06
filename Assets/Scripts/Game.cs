using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] PlayerPropertiesSave playerPropertiesSave;
    [SerializeField] InGameSettingsPreset GamePreset;
    [SerializeField] Transform bottomLeftMapCorner;
    [SerializeField] Transform topRightMapCorner;
    [SerializeField] float nodeCreatorCellSize;
    [SerializeField] LayerMask nodeCreatorLayerMask;
    [SerializeField] Transform from;
    [SerializeField] Transform to;
    [SerializeField] MeeleWeaponTemplate startingWeapon;
    [SerializeField] ItemTemplate[] startingInventory;
    [SerializeField] InventoryUI inventoryUI;
    [SerializeField] EquipmentUI equipmentUI;
    void Awake()
    {
        InGameSettings.ChangePreset(GamePreset);
        NodeCreatorSettings settings = new NodeCreatorSettings
        {
            bottomLeftCorner = bottomLeftMapCorner.position,
            topRightCorner = topRightMapCorner.position,
            cellSize = nodeCreatorCellSize,
            unwalkableLayers = nodeCreatorLayerMask
        };
        NodeCreator.Initialize(settings);
        GameObject playerGO = Instantiate(playerPrefab);
        Player.SetPlayer(playerGO, playerPropertiesSave);
        Inventory inventory = new Inventory(10);
        foreach (ItemTemplate item in startingInventory)
        {
            inventory.AddItem(item.CreateInstance());
        }
        ItemsOnPlayer.SetInventory(inventory, startingWeapon.CreateInstance());
        inventoryUI.Initialize();
        equipmentUI.Initialize();
        //Pathfinding p = new Pathfinding();
        //var path = p.FindPath(from.position, to.position);
        //VisualDebug.DrawPath(path, Color.blue, 14f);
    }
}
