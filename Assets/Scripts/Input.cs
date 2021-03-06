using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Input : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;
    bool inventoryOpened = false;
    bool ingamePresetMenuOpened = false;
    public static event Action<Vector2> MoveClicked;
    public static event Action PlayerShoot;
    public static event Action PlayerInteracted;
    public static event Action<Vector3> PlayerMovedMouseInWorld;
    public static event Action<float> PlayerMovedMouse;
    public static event Action<bool> InventoryModeChangedTo;
    public static event Action<bool> IngamePreserMenuClick;
    Vector3 mousePos;
    void Update()
    {
        #region moving
        if (UnityEngine.Input.GetKey(KeyCode.W))
            MoveClicked?.Invoke(Vector2.up);
        else if (UnityEngine.Input.GetKey(KeyCode.A))
            MoveClicked?.Invoke(Vector2.left);
        else if (UnityEngine.Input.GetKey(KeyCode.S))
            MoveClicked?.Invoke(Vector2.down);
        else if (UnityEngine.Input.GetKey(KeyCode.D))
            MoveClicked?.Invoke(Vector2.right);
        #endregion

        #region mouse click
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                PlayerShoot?.Invoke();
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                PlayerInteracted?.Invoke();
            }
        }
        #endregion

        #region mouse move
        float mouseMove = UnityEngine.Input.GetAxis("Mouse X");
        if (mouseMove != 0)
            PlayerMovedMouse?.Invoke(mouseMove);
        //Vector3 currentMousePos = UnityEngine.Input.mousePosition;
        //if (currentMousePos.x != mousePos.x)
        //{
        //    float difference = currentMousePos.x - mousePos.x;
        //    PlayerMovedMouse?.Invoke(difference);
        //}
        //mousePos = currentMousePos;
        #endregion

        if (UnityEngine.Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryOpened = !inventoryOpened;
            InventoryModeChangedTo?.Invoke(inventoryOpened);
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.P))
        {
            ingamePresetMenuOpened = !ingamePresetMenuOpened;
            IngamePreserMenuClick?.Invoke(ingamePresetMenuOpened);
        }
    }
}
