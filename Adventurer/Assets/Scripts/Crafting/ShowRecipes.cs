using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShowRecipes : MonoBehaviour
{
    public GameObject recipePrefab;
    public GameObject downArrow;
    public GameObject descBox;

    public PlayerData data;

    public int currentIndex = 0;

    void OnEnable()
    {
        RenderRecipes(currentIndex);
    }

    void Update()
    {
        if (Input.mouseScrollDelta.y < 0 && currentIndex + 4 < data.recipes.Count)
        {
            currentIndex += 1;
            RenderRecipes(currentIndex);
        }
        else if (Input.mouseScrollDelta.y > 0 && currentIndex > 0)
        {
            currentIndex -= 1;
            RenderRecipes(currentIndex);
        }
    }

    public void RenderRecipes(int index)
    {
        Debug.Log("RENDER!");
        foreach (Transform t in transform)
        {
            if (t.gameObject.CompareTag("MenuItem"))
            {
                Destroy(t.gameObject);
            }
        }

        if (data.recipes.Count > index + 4)
        {
            downArrow.SetActive(true);
        }
        else
        {
            downArrow.SetActive(false);
        }
        Debug.Log(data.recipes.Count);
        List<ConsumableRecipeSO> toRender = data.recipes.Skip(index).ToList();
        toRender = toRender.Take(6).ToList();

        for(int i = 0; i < toRender.Count; i++)
        {
            GameObject recipe = Instantiate(recipePrefab, transform.position + new Vector3(0, 200 - (100 * i), 0), Quaternion.identity, transform);
            recipe.GetComponent<RecipeButton>().Fill(toRender[i]);
        }
    }
}
