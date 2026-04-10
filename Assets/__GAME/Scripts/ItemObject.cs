using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public string itemID;
    public int count = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ItemController itemController = FindAnyObjectByType<ItemController>();


            if (itemController != null)
            {
                itemController.AddItem(itemID, count);
                Destroy(gameObject);
            }
        }
    }
}
