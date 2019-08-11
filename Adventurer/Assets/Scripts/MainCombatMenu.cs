using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCombatMenu : MonoBehaviour
{
    static MainCombatMenu instance;
    public GameObject indicator;
    public Vector3 indpos;
    public List<List<MenuController.Category>> lists = new List<List<MenuController.Category>>();
    public List<MenuController.Category> LeftCategories = new List<MenuController.Category>();
    public List<MenuController.Category> RightCategories = new List<MenuController.Category>();
    public MenuController.Category pickedOption;
    public int currentList;
    public int currentIndex;
    public GameObject menuController;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        indicator = this.gameObject;
        indpos = indicator.transform.position;
        LeftCategories.Add(MenuController.Category.Attack);
        LeftCategories.Add(MenuController.Category.Items);
        RightCategories.Add(MenuController.Category.Spells);
        RightCategories.Add(MenuController.Category.Run);
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
        if(Input.GetKeyDown(KeyCode.Return))
        {
            menuController.GetComponent<MenuController>().ChangeMenu(pickedOption);
        }
    }

    public void MoveIndicator(float x, float y)
    {
        indicator.transform.position = indpos + new Vector3(x*200, + y*-55, 0);
        Debug.Log(indicator.transform.position.x + ", " + indicator.transform.position.y);
    }


}
