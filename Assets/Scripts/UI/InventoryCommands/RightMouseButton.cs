using System;
using UnityEngine;
using UnityEngine.UI;

public class RightMouseButton : MonoBehaviour
{
    [SerializeField]
    Text text;
    InventoryCommand command;
    Action onClickAction;
    public void Initialize(InventoryCommand command, Action onClick)
    {
        this.command = command;
        text.text = command.CommandName;
        onClickAction = onClick;
    }
    public void OnClick()
    {
        command.Execute();
        onClickAction();
    }
}
