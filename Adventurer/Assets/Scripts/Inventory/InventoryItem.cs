using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public bool isSelected;
    public ItemSO otherSO;
    public ConsumableSO consumableSO;
    public int itemAmount;

    public Image image;
    public Text itemName;
    public Text itemType;
    public Text amount;

    public void Fill(Inventory.InventoryOtherItem item)
    {
        otherSO = item.so;
        itemAmount = item.amount;
        image.sprite = item.so.icon;
        itemName.text = item.so.item_name;
        itemType.text = item.so.type.ToString();
        amount.text = itemAmount.ToString();
    }

    public void Fill(Inventory.InventoryConsumableItem item)
    {
        consumableSO = item.so;
        itemAmount = item.amount;
        image.sprite = item.so.icon;
        itemName.text = item.so.itemName;
        itemType.text = item.so.type.ToString();
        amount.text = itemAmount.ToString();
    }

    public void OnButtonClick()
    {
        GameObject descBox = transform.parent.GetComponent<ShowInventory>().descBox;
        if(isSelected == false)
        {
            descBox.GetComponent<DescBox>().Fill(otherSO);
            descBox.SetActive(true);
            isSelected = true;
        }
        else
        {
            descBox.SetActive(false);
            isSelected = false;
        }
    }
}
