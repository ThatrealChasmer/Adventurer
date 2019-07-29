using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCombatMenu : MonoBehaviour
{
    static MainCombatMenu instance;
    public GameObject indicator;
    public List<Category> LeftCategories;
    public List<Category> RightCategories;
    public Category pickedOption;
    public string currentList;
    public int currentIndex;

    public enum Category{
        Attack,
        Spells,
        Items,
        Run
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        LeftCategories.Add(Category.Attack);
        LeftCategories.Add(Category.Items);
        RightCategories.Add(Category.Spells);
        RightCategories.Add(Category.Run);
        currentList = "LeftCategories";
        currentIndex = 0;
        pickedOption = LeftCategories[currentIndex];
        pickedOption = 
    }

    // Update is called once per frame
    void Update()
    {
        if(currentList == "LeftCategories")
        {
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentIndex++;
                pickedOption = LeftCategories[currentIndex];
            }
        }
    }
}
