using UnityEngine;
/// <summary>
/// взаимодействие с объектами
/// </summary>
public class PlayerInteractor
{
    Player owner;
    const float maxInteractionDistance = 1.1f;
    public PlayerInteractor(Player owner)
    {
        this.owner = owner;
        Input.PlayerInteracted += OnPlayerInteract;
    }
    void OnPlayerInteract()
    {
        var mouseInWorld = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
        if (Vector2.Distance(mouseInWorld, owner.PlayerPosition) > maxInteractionDistance)
        {
            Debug.Log("Слишком далеко");
            return;
        }
        var hitInfo = Physics2D.RaycastAll(mouseInWorld, Vector3.zero);
        foreach (var hit in hitInfo)
        {
            Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();
            if (interactable != null)
            {
                //Debug.Log("попал рейкастом");
                interactable.OnInteraction(owner);
            }
        }
    }
}
