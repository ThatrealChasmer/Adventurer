using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int TurnIndex;
    TurnSystem2 TurnSystemReference;
    private void Awake()
    {
        TurnSystemReference = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<TurnSystem2>();
    }
    public void Act()
    {
        Debug.Log("Attack by " + TurnIndex);
        TurnSystemReference.EndTurn();
    }
}
