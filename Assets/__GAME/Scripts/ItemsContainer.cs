using UnityEngine;

public enum ItemType
{
    None,
    HPPack,
    Hearts
}

public class ItemsContainer : MonoBehaviour
{
    public ItemType itemType;
    public float value;

    void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Player"))
       {
            switch (itemType)
            {
                case ItemType.HPPack:
                    collision.gameObject.GetComponentInParent<PlayerController>().Heal(value);
                    break;
                
            }
       }
    }
}
