using UnityEngine;

public class PlayerRotator
{
    Transform playerTransform;
    Rigidbody2D rb;
    public PlayerRotator()
    {
        playerTransform = Player.GO.transform;
        rb = Player.GO.GetComponent<Rigidbody2D>();
        Input.PlayerMovedMouse += OnMouseMove;
        Input.InventoryModeChangedTo += OnInventoryOpenClose;
        Input.IngamePreserMenuClick += OnIngamePresetChanged;
    }


    void OnMouseMove(float diff)
    {
        float newAngle = playerTransform.eulerAngles.z - diff * Player.Properties.Coeff;
        //Debug.Log($"diff {diff} curr rotation {playerTransform.eulerAngles.z} newAngle {newAngle}");
        rb.MoveRotation(newAngle);
    }
    void OnIngamePresetChanged(bool opened)
    {
        if (opened)
            Input.PlayerMovedMouse -= OnMouseMove;
        else
            Input.PlayerMovedMouse += OnMouseMove;
    }
    void OnInventoryOpenClose(bool opened)
    {
        if (opened)
            Input.PlayerMovedMouse -= OnMouseMove;
        else
            Input.PlayerMovedMouse += OnMouseMove;
    }


    #region старые варианты
    //вращение через *=
    //float newAngle = diff * coeff;
    //if (newAngle > maxAngle)
    //{
    //    newAngle = maxAngle;
    //    Debug.Log("Быстро");
    //}
    //playerTransform.rotation *= Quaternion.AngleAxis(newAngle, Vector3.forward);
    // Camera.main.transform.rotation *= Quaternion.AngleAxis(newAngle, Vector3.forward);

    //Вращение на курсор
    //void Update()
    //{
    //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
    //    var direction = transform.position - mousePos;
    //    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //    transform.eulerAngles = new Vector3(0, 0, angle);
    //}
    #endregion
}
