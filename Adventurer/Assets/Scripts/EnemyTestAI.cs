using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestAI : MonoBehaviour
{
    private TurnSystem TurnSystem;

    private void Start()
    {
        TurnSystem = GameObject.FindGameObjectWithTag("Box").GetComponent<TurnSystem>();
        TurnSystem.NewTurn += Action;
    }

    private void Action(int index)
    {
        if (index == GetComponent<EnemyStats>().TurnIndex)
        {
            Debug.Log("Enemy Action");
            PlayerStats.TakeDamage(10);
            Debug.Log(PlayerStats.playerStats.currentHealth);
            TurnSystem.EndTurn();
        }
    }


}
