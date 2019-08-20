using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSwapper : MonoBehaviour
{

    public GameObject main;
    public GameObject attack;
    public GameObject spells;
    public GameObject items;
    public GameObject selection;
    public GameObject afterAction;

    public GameObject currentMenu;
    public GameObject previousMenu;

    public GameObject loot;
    public GameObject stats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void swapMenu(string menu)
    {
        GameObject tmp = previousMenu;
        previousMenu = currentMenu;
        currentMenu.SetActive(false);
        switch(menu)
        {
            case "Main":
                currentMenu = main;
                break;
            case "Attack":
                currentMenu = attack;
                break;
            case "Spells":
                currentMenu = spells;
                break;
            case "Items":
                currentMenu = items;
                break;
            case "Selection":
                currentMenu = selection;
                break;
            case "AfterAction":
                currentMenu = afterAction;
                break;
            case "Previous":
                currentMenu = tmp;
                break;  
        }
        currentMenu.SetActive(true);
    }

    public void SwapBattleEnd(GameObject menu)
    {
        currentMenu.SetActive(false);
        menu.SetActive(true);
        currentMenu = menu;
    }

    public void LoadScene(string scene)
    {
        SceneLoader.Load(scene);
    }
}
