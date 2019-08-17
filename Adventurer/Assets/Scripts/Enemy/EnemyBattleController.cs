using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBattleController : MonoBehaviour
{
    public bool isSelected;

    public GameObject battleManager;
    public GameObject button;
    public GameObject border;
    public GameObject selectionManager;

    public void SetButton()
    {
        battleManager = GameObject.Find("BattleManager");
        selectionManager = GameObject.Find("SelectionManager");
        //button.GetComponent<Button>().onClick.AddListener(SelectDeselect);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectDeselect()
    {
        if(isSelected == false && selectionManager.GetComponent<SelectionManager>().selections > 0)
        {
            isSelected = true;
            border.SetActive(true);
            battleManager.GetComponent<BattleManager>().targets.Add(gameObject);
            selectionManager.GetComponent<SelectionManager>().selections--;
        }
        else if(isSelected == true)
        {
            isSelected = false;
            border.SetActive(false);
            battleManager.GetComponent<BattleManager>().targets.Remove(gameObject);
            selectionManager.GetComponent<SelectionManager>().selections++;
        }
    }

    public void SetInteractive(bool state)
    {
        button.GetComponent<Button>().interactable = state;
    }
    
}
