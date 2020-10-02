using UnityEngine;

public class ItemOnGround : MonoBehaviour, Interactable
{
    [SerializeField]
    ItemTemplate template;
    Item item;
    public Item Item => item;
    void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = template.Sprite;
        item = new Item(template);
    }
    public void OnInteraction(Player player)
    {
        if (ItemsOnPlayer.PlayerInventory.AddItem(Item))
            Destroy(gameObject);
    }
}
