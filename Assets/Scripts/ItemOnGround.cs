using UnityEngine;

public class ItemOnGround : MonoBehaviour, Interactable
{
    [SerializeField]
    ItemTemplate item;
    public ItemTemplate Item => item;
    void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = item.Sprite;
    }
    public void OnInteraction(Player player)
    {
        if (ItemsOnPlayer.PlayerInventory.AddItem(Item))
            Destroy(gameObject);
    }
}
