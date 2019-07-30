using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public enum Category
    {
        Main,
        Attack,
        Spells,
        Items,
        Run
    }
    public List<GameObject> subMenus = new List<GameObject>();
    public GameObject currentMenu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && currentMenu != subMenus[0])
        {
            currentMenu.SetActive(false);
            currentMenu = subMenus[0];
            currentMenu.SetActive(true);
        }
    }

    public void ChangeMenu(Category cat)
    {
        switch(cat)
        {
            case Category.Main:
                currentMenu.SetActive(false);
                currentMenu = subMenus[0];
                currentMenu.SetActive(true);
                break;
            case Category.Attack:
                currentMenu.SetActive(false);
                currentMenu = subMenus[1];
                currentMenu.SetActive(true);
                break;
            case Category.Spells:
                currentMenu.SetActive(false);
                currentMenu = subMenus[2];
                currentMenu.SetActive(true);
                break;
            case Category.Items:
                currentMenu.SetActive(false);
                currentMenu = subMenus[3];
                currentMenu.SetActive(true);
                break;
            case Category.Run:
                break;
        }
             
    }
}
