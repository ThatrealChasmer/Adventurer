using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCombatMenu : MonoBehaviour
{
    static MainCombatMenu instance;
    public GameObject indicator;
    public Vector3 indpos;
    public List<List<Category>> lists = new List<List<Category>>();
    public List<Category> LeftCategories = new List<Category>();
    public List<Category> RightCategories = new List<Category>();
    public Category pickedOption;
    public int currentList;
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
        indicator = this.gameObject;
        indpos = indicator.transform.position;
        LeftCategories.Add(Category.Attack);
        LeftCategories.Add(Category.Items);
        RightCategories.Add(Category.Spells);
        RightCategories.Add(Category.Run);
        lists.Add(LeftCategories);
        lists.Add(RightCategories);
        currentList = 0;
        currentIndex = 0;
        pickedOption = lists[currentList][currentIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && currentList < lists.Count - 1)
            {
                currentList++;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && currentList > 0)
            {
                currentList--;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && currentIndex < lists[currentList].Count - 1)
            {
                currentIndex++;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && currentIndex > 0)
            {
                currentIndex--;
            }
            pickedOption = lists[currentList][currentIndex];
            MoveIndicator(currentList, currentIndex);
        }
    }

    public void MoveIndicator(float x, float y)
    {
        indicator.transform.position = indpos + new Vector3(x*200, + y*-55, 0);
        Debug.Log(indicator.transform.position.x + ", " + indicator.transform.position.y);
    }
}
