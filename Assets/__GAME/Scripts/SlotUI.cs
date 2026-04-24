using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text caption;
    public TMP_Text count;

    public void SetItem(Item item, int itemCount)
    {
        icon.sprite = null;
        if (itemCount > 0)
        {
            caption.text = item.name;
            count.text = itemCount.ToString();
        }
        else
        {
            caption.text = "Empty";
            count.text = "";
        }
    }

    void OnEnable()
    {
        icon.sprite = null;
        caption.text = "Empty";
        count.text = "";
    }
}
