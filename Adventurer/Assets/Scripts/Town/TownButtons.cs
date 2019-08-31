using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TownButtons: MonoBehaviour
{
    public Inventory inv;

    public List<ItemSO> otherItems;
    public List<ConsumableSO> consumables;

    public PlayerStatistics stats;
    public Text nameText;

    private void Start()
    {
        nameText.text = stats.playerName;

        foreach(ItemSO item in otherItems)
        {
            inv.AddItem(item, 1);
        }

        foreach(ConsumableSO item in consumables)
        {
            inv.AddItem(item, 1);
        }
    }

    public void LoadScene(string name)
    {
        if(name == "Hall")
        {
            if(stats.playerName == "")
            {
                SceneLoader.Load("PlayerCreation");
            }
            else
            {

            }
        }
        else if(name == "Battle" && stats.playerName != null)
        {
            SceneLoader.Load(name);
        }
        else
        {
            SceneLoader.Load(name);
        }
    }
}
