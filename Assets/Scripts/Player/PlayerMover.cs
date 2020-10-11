using UnityEngine;

public class PlayerMover
{
    Rigidbody2D rb;
    PlayerProperties properties;
    public PlayerMover()
    {
        rb = Player.GO.GetComponent<Rigidbody2D>();
        properties = Player.Properties;
    }

    public void ListenToInput()
    {
        Input.MoveClicked += OnPlayerInput;
    }
    public void NotListenToInput()
    {
        Input.MoveClicked -= OnPlayerInput;
    }

    private void OnPlayerInput(Vector2 direction)
    {
        //Debug.Log($"up {rb.transform.up} right {rb.transform.right}");
        if (direction == Vector2.up)
            rb.AddForce(rb.transform.up *properties.ForceMultiply);
        else if (direction == Vector2.down)
            rb.AddForce(-rb.transform.up * properties.ForceMultiply);
        else if (direction == Vector2.left)
            rb.AddForce(-rb.transform.right * properties.ForceMultiply);
        else if (direction == Vector2.right)
            rb.AddForce(rb.transform.right * properties.ForceMultiply);  
    }
}
