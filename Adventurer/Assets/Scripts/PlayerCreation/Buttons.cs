using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons: MonoBehaviour
{
    public GameObject menuManager;

    int pointsLeft;
    
    private void Update()
    {
        pointsLeft = menuManager.GetComponent<PlayerCreationController>().pointsLeft;
        if(pointsLeft == 0)
        {
            transform.GetChild(2).gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            transform.GetChild(2).gameObject.GetComponent<Button>().interactable = true;
        }
        
        if(int.Parse(transform.GetChild(0).gameObject.GetComponent<Text>().text) <= 1)
        {
            transform.GetChild(1).GetComponent<Button>().interactable = false;
        }
        else
        {
            transform.GetChild(1).GetComponent<Button>().interactable = true;
        }
    }
}
