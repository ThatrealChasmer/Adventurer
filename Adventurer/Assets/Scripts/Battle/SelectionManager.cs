using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public int selections;
    public MenuSwapper ms;
    // Start is called before the first frame update
    void Start()
    {
        SetSelection(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSelection(bool state)
    {
        if(state)
        {
            ms.swapMenu("Selection");
        }
        else
        {
            ms.swapMenu("Previous");
        }
        Debug.Log("Selection set to " + state.ToString());
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyBattleController>().SetInteractive(state);
        }
    }

}
