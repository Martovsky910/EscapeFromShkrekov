using System.Collections.Generic;
using UnityEngine;

public class Inv_ContextMenu : MonoBehaviour
{
    [SerializeField]
    GameObject buttonPrefab;
    List<GameObject> currentButtons = new List<GameObject>();
    void Awake()
    {
        InventoryButton.OnMouseRightClick += Show;
        Input.InventoryModeChangedTo += OnInventoryModeChange;
    }
    void OnInventoryModeChange(bool isOpened)
    {
        if (!isOpened)
            Close();
    }
    public void Show(Item item, Inventory inventory)
    {
        List<InventoryCommand> commands = CreateCommands(item, inventory);

        currentButtons.ForEach(b => Destroy(b));
        gameObject.SetActive(true);
        foreach (InventoryCommand command in commands)
        {
            GameObject button = Instantiate(buttonPrefab, transform);
            currentButtons.Add(button);
            Inv_Btn_ContextMenu rmb = button.GetComponent<Inv_Btn_ContextMenu>();
            rmb.Initialize(command, Close);
        }
    }
    void Close()
    {
        gameObject.SetActive(false);
    }
    List<InventoryCommand> CreateCommands(Item item, Inventory inventory)
    {
        List<InventoryCommand> commands = new List<InventoryCommand>();

        commands.Add(new InvComm_Drop(inventory, item));
        if (item is IUsableItem)
            commands.Add(new InvComm_Use(inventory, item));
        if (item is IEqipable)
            commands.Add(new InvComm_Equip(inventory, item));

        return commands;
    }
}
