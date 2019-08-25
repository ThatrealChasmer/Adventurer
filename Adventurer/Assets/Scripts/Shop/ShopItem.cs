using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public bool isSelected;
    public ItemSO so;

    public Image image;
    public Text itemName;
    public Text itemType;

    public PlayerData player;
    public Inventory inventory;

    public void Fill(ItemSO item)
    {
        Debug.Log(item.item_name);
        so = item;
        image.sprite = so.icon;
        itemName.text = so.item_name;
        itemType.text = so.type.ToString();
    }

    public void OnButtonClick()
    {
        Debug.Log("bought " + itemName.text);
        player.money -= so.gold;
        inventory.AddItem(so, 1);
    }
}
