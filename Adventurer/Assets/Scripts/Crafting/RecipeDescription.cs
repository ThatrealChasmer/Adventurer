using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeDescription : MonoBehaviour
{
    public Text itemName;
    public Text type;
    public Text desc;
    public List<Text> materialFields;
    public ConsumableRecipeSO recipeSO;
    int materialCounter;

    public void Fill(ConsumableRecipeSO so)
    {
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
