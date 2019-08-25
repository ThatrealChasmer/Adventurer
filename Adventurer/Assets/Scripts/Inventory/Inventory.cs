using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    public List<InventoryOtherItem> otherItems = new List<InventoryOtherItem>();
    public List<InventoryConsumableItem> consumables = new List<InventoryConsumableItem>();
    
    
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

    public class InventoryConsumableItem
    {
        public ConsumableSO so;
        public int amount;
        
        public InventoryConsumableItem(ConsumableSO so, int amount)
        {
            this.so = so;
            this.amount = amount;
        }
    }

    public void AddItem(ItemSO item, int amount)
    {
        if(otherItems.Where(obj => obj.so.item_name == item.item_name).FirstOrDefault() == null)
        {
            otherItems.Add(new InventoryOtherItem(item, amount));
        }
        else
        {
            otherItems.Where(obj => obj.so.item_name == item.item_name).FirstOrDefault().amount += amount;
        }
    }

    public void AddItem(ConsumableSO item, int amount)
    {
        if (consumables.Where(obj => obj.so.itemName == item.itemName).FirstOrDefault() == null)
        {
            consumables.Add(new InventoryConsumableItem(item, amount));
        }
        else
        {
            consumables.Where(obj => obj.so.itemName == item.itemName).FirstOrDefault().amount += amount;
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

    public void RemoveItem(ConsumableSO item, int amount)
    {
        InventoryConsumableItem toRemove = consumables.Where(obj => obj.so.itemName == item.itemName).FirstOrDefault();
        toRemove.amount -= amount;
        if (toRemove.amount <= 0)
        {
            consumables.Remove(toRemove);
        }
    }

    public void ClearInventory()
    {
        otherItems.Clear();
    }
}
