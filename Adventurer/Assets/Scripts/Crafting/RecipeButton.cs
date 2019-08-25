using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeButton : MonoBehaviour
{
    public ConsumableRecipeSO recipe;
    public ConsumableSO item;

    public Text itemName;
    public Image icon;

    bool selected;

    public void Fill(ConsumableRecipeSO so)
    {
        recipe = so;
        item = so.item;
        itemName.text = item.itemName;
        icon.sprite = item.icon;
    }

    public void OnButtonClick()
    {
        GameObject descBox = transform.parent.GetComponent<ShowRecipes>().descBox;
        if(descBox.activeSelf == false)
        {
            descBox.GetComponent<RecipeDescription>().Fill(recipe);
            descBox.SetActive(true);
        }
        else
        {
            if (descBox.GetComponent<RecipeDescription>().recipeSO == recipe)
            {
                descBox.SetActive(false);
            }
            else
            {
                descBox.GetComponent<RecipeDescription>().Fill(recipe);
            }
        }
    }
}
