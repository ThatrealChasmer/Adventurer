using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RecipeDescription : MonoBehaviour
{
    public Text itemName;
    public Text type;
    public Text desc;
    public List<Text> materialFields;
    public ConsumableRecipeSO recipeSO;
    public Inventory inv;
    public Button btn;
    public ShowInventory si;

    int materialCounter;

    public void Fill(ConsumableRecipeSO so)
    {
        btn.interactable = true;
        Clear();
        materialCounter = 0;
        recipeSO = so;
        itemName.text = recipeSO.item.itemName;
        type.text = recipeSO.item.type;
        desc.text = recipeSO.item.description;

        for (int i = 0; i < recipeSO.materials.Count; i++)
        {
            materialFields[i].text = recipeSO.materials[i].item_name + " (" + recipeSO.mAmounts[i] + ")";
        }

        for(int i = 0; i < recipeSO.ingredients.Count; i++)
        {
            materialFields[i + recipeSO.materials.Count].text = recipeSO.ingredients[i].itemName + " (" + recipeSO.iAmounts[i] + ")";
        }

        for(int i = 0; i < recipeSO.materials.Count; i++)
        {
            if(inv.otherItems.Where(obj => obj.so == recipeSO.materials[i]).FirstOrDefault() == null || inv.otherItems.Where(obj => obj.so == recipeSO.materials[i]).FirstOrDefault().amount < recipeSO.mAmounts[i])
            {
                btn.interactable = false;
                break;
            }
        }

        for (int i = 0; i < recipeSO.ingredients.Count; i++)
        {
            if (inv.consumables.Where(obj => obj.so == recipeSO.ingredients[i]).FirstOrDefault() == null || inv.consumables.Where(obj => obj.so == recipeSO.ingredients[i]).FirstOrDefault().amount < recipeSO.iAmounts[i])
            {
                btn.interactable = false;
                break;
            }
        }

    }

    public void Craft()
    {
        for(int i = 0; i < recipeSO.materials.Count; i++)
        {
            inv.RemoveItem(recipeSO.materials[i], recipeSO.mAmounts[i]);
        }

        for(int i = 0; i < recipeSO.ingredients.Count; i++)
        {
            inv.RemoveItem(recipeSO.ingredients[i], recipeSO.iAmounts[i]);
        }

        inv.AddItem(recipeSO.item, 1);

        si.ChangeList(si.listType);
        Fill(recipeSO);
    }

    public void Clear()
    {
        itemName.text = null;
        type.text = null;
        desc.text = null;

        foreach(Text t in materialFields)
        {
            t.text = null;
        }
    }
}
