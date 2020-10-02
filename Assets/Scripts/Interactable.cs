public interface Interactable
{
    Item Item { get; }
    void OnInteraction(Player player);
}