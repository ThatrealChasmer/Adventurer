using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public bool isSelected;
    public ItemSO so;
    public int itemAmount;

    public Image image;
    public Text itemName;
    public Text itemType;
    public Text amount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fill(Inventory.InventoryOtherItem item)
    {
        so = item.so;
        itemAmount = item.amount;
        image.sprite = item.so.icon;
        itemName.text = item.so.item_name;
        itemType.text = item.so.type.ToString();
        amount.text = itemAmount.ToString();
    }

    public void OnButtonClick()
    {
        GameObject descBox = transform.parent.GetComponent<ShowInventory>().descBox;
        if(isSelected == false)
        {
            descBox.GetComponent<DescBox>().Fill(so);
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
