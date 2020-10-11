using UnityEngine;
using UnityEngine.UI;

public class InteractionTextUI : MonoBehaviour
{
    [SerializeField]
    Text text;
    void Awake()
    {
        PlayerInteractor.PlayerCanInteract += OnPlayerCanInteract;
    }

    private void OnPlayerCanInteract(Interactable interactable)
    {
        if (interactable != null)
            text.text = interactable.InteractionText;
        else
            text.text = "";
    }
}
