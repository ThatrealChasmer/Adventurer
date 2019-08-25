using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{
    public ItemSO item;
    public PlayerData player;
    public Inventory inventory;

    public void BuyItem()
    {
        player.money -= item.gold;
        inventory.AddItem(item, 1);
    }
}
