using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterAction : MonoBehaviour
{
    public Text textBox;

    public BattleManagerConnector connector;

    public TurnSystem turnSystem;

    public MenuSwapper ms;

    private void OnEnable()
    {
        if(connector.caster != "Player")
        {
            textBox.text = connector.caster + " used " + connector.enemyAttack.attackName + ".";
        }
        else
        {
            textBox.text = connector.caster + " used " + connector.skill.skillName + ".";
        }
    }


    public void NextLine()
    {
        if(turnSystem.index == turnSystem.PlayerIndex - 1)
        {
            Debug.Log("Runda Gracza");
            ms.swapMenu("Main");
        }
        else
        {
            gameObject.SetActive(false);
        }
        turnSystem.EndTurn();
        
    }
}
