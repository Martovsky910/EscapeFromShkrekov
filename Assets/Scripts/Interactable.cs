public interface Interactable
{
    Item Item { get; }
    void OnInteraction();
    string InteractionText { get; }
}