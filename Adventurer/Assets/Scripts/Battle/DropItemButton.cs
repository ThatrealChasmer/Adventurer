using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropItemButton : MonoBehaviour
{
    public Inventory inv;
    public BattleInfoSO info;

    public ItemSO so;
    public int itemAmount;

    public Image image;
    public Text itemName;
    public Text itemType;
    public Text amount;

    public void Fill(ItemSO so, int amount)
    {
        this.so = so;
        itemAmount = amount;
        image.sprite = so.icon;
        itemName.text = so.item_name;
        itemType.text = so.type.ToString();
        this.amount.text = amount.ToString();
    }

    public void OnButtonClick()
    {
        LootMenu lm = transform.parent.GetComponent<LootMenu>();
        inv.AddItem(so, itemAmount);
        info.items.Remove(so);
        if(lm.currentIndex + 4 >= lm.items.Count)
        {
            lm.currentIndex = Mathf.Clamp(lm.items.Count - 4, 0, 100);
            lm.RenderItems(lm.currentIndex);

        }
        else
        {
            lm.RenderItems(lm.currentIndex);
        }
    }
}
