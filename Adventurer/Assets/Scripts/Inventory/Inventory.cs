using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    public List<InventoryOtherItem> otherItems = new List<InventoryOtherItem>();
    
    
    public class InventoryOtherItem
    {
        public ItemSO so;
        public int amount;


        public InventoryOtherItem(ItemSO so, int amount)
        {
            this.so = so;
            this.amount = amount;
        }
    }

    public void AddItem(ItemSO item, int amount)
    {
        if(otherItems.Where(obj => obj.so.item_name == item.item_name).FirstOrDefault() == null)
        {
            Debug.Log("Added new item!!!");
            otherItems.Add(new InventoryOtherItem(item, amount));
        }
        else
        {
            Debug.Log("Added item!!!");
            otherItems.Where(obj => obj.so.item_name == item.item_name).FirstOrDefault().amount += amount;
        }
    }

    public void RemoveItem(ItemSO item, int amount)
    {
        InventoryOtherItem toRemove = otherItems.Where(obj => obj.so.item_name == item.item_name).FirstOrDefault();
        toRemove.amount -= amount;
        if(toRemove.amount <= 0)
        {
            otherItems.Remove(toRemove);
        }
    }

    public void ClearInventory()
    {
        otherItems.Clear();
    }
}
