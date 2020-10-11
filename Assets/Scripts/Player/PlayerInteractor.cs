using System;
using UnityEngine;
/// <summary>
/// взаимодействие с объектами
/// </summary>
public class PlayerInteractor : MonoBehaviour
{
    [SerializeField]
    float maxDistance;
    public static Action<Interactable> PlayerCanInteract;
    void Awake()
    {
        Input.PlayerInteracted += OnPlayerInteract;
    }
    void Update()
    {
        Interactable item = getFirstInteractable();
        PlayerCanInteract?.Invoke(item);
    }
    void OnPlayerInteract()
    {
        Interactable item = getFirstInteractable();
        if (item != null)
        {
            item.OnInteraction();
        }
    }
    Interactable getFirstInteractable()
    {
        RaycastHit2D[] result = Physics2D.BoxCastAll(transform.position, new Vector2(1f, 1f), 0, transform.up, maxDistance);
        foreach (var hit in result)
        {
            Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();
            if (interactable != null)
            {
                return interactable;
            }
        }
        return null;
    }
}
