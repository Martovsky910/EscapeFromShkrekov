using System;
using System.Net.Http.Headers;
using UnityEngine;

public class PlayerMover
{
    Rigidbody2D rb;
    float forceMultiply;
    public PlayerMover(Rigidbody2D rb, float forceMultiply)
    {
        this.rb = rb;
        this.forceMultiply = forceMultiply;
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
            rb.AddForce(rb.transform.up * forceMultiply);
        else if (direction == Vector2.down)
            rb.AddForce(-rb.transform.up * forceMultiply);
        else if (direction == Vector2.left)
            rb.AddForce(-rb.transform.right * forceMultiply);
        else if (direction == Vector2.right)
            rb.AddForce(rb.transform.right * forceMultiply);  
    }
}
