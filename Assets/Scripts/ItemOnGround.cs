using UnityEngine;

public class ItemOnGround : MonoBehaviour, Interactable
{
    [SerializeField]
    ItemTemplate template;
    [SerializeField]
    int StacksAmount;
    Item item;
    public Item Item => item;
    void Awake()
    {
        item = template.CreateInstance();
        item.ChangeStackAmount(StacksAmount);
    }
    public void OnInteraction()
    {
        if (ItemsOnPlayer.PlayerInventory.AddItem(Item))
            Destroy(gameObject);
    }
    void OnValidate()
    {
        if (template == null)
            gameObject.name = "Empty item on ground";
        else
        {
            GetComponent<SpriteRenderer>().sprite = template.WorldSprite;
            transform.localScale = template.WorldSize;
            GetComponent<BoxCollider2D>().size = template.WorldSize;
            gameObject.name = template.name + " on ground";
        }
    }

    public string InteractionText => $"Взять {template.ItemName}";
}
