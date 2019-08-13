using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSwapper : MonoBehaviour
{

    public GameObject main;
    public GameObject attack;
    public GameObject spells;
    public GameObject items;

    public GameObject currentMenu;
    // Start is called before the first frame update
    void Start()
    {
        currentMenu = main;
    }

    public void swapMenu(string menu)
    {
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
                
        }
        currentMenu.SetActive(true);
    }

    public void LoadScene(string scene)
    {
        SceneLoader.Load(scene);
    }
}
