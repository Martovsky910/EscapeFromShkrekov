using System.Collections.Generic;
using UnityEngine;

public class RBM_Menu : MonoBehaviour
{
    [SerializeField]
    GameObject buttonPrefab;
    List<GameObject> currentButtons = new List<GameObject>();
    void Awake()
    {
        InventoryButton.OnMouseRightClick += Show;
    }
    public void Show(Item item, Inventory inventory)
    {
        List<InventoryCommand> commands = createCommands(item, inventory);

        currentButtons.ForEach(b => Destroy(b));
        gameObject.SetActive(true);
        foreach (InventoryCommand command in commands)
        {
            GameObject button = Instantiate(buttonPrefab, transform);
            RightMouseButton rmb = button.GetComponent<RightMouseButton>();
            rmb.Initialize(command, Close);
        }
    }
    void Close()
    {
        gameObject.SetActive(false);
    }
    private static List<InventoryCommand> createCommands(Item item, Inventory inventory)
    {
        List<InventoryCommand> commands = new List<InventoryCommand>();

        commands.Add(new InvComm_Drop(inventory, item));
        return commands;
    }
}
