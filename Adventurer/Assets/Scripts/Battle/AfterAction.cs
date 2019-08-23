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

    bool startingText = true;

    public TextWriter writer;

    private void OnEnable()
    {
        if(startingText)
        {
            writer.fullText = "Enemies approach!";
        }
        else
        {
            if (connector.caster != "Player")
            {
                writer.fullText = connector.caster + " used " + connector.enemyAttack.attackName + ".";
            }
            else
            {
                writer.fullText = connector.caster + " used " + connector.skill.skillName + ".";
            }
        }
        writer.StartTyping();
    }


    public void NextLine()
    {
        if(writer.isTyping == false)
        {
            if (startingText)
            {
                startingText = false;
                turnSystem.StartTurn();
                if (turnSystem.FirstTurn && turnSystem.enemies[0].name.Equals("Player"))
                {
                    Debug.Log("Runda Gracza");
                    ms.swapMenu("Main");
                }
            }
            else
            {
                if ((turnSystem.index < turnSystem.enemies.Count - 1 && turnSystem.enemies[turnSystem.index+1].name.Equals("Player")) || (turnSystem.index == turnSystem.enemies.Count - 1 && turnSystem.enemies[0].name.Equals("Player")))
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
        else
        {
            writer.Skip();
        }
    }
}
