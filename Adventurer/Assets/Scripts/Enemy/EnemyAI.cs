using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int TurnIndex;
    TurnSystem TurnSystemReference;
    private void Awake()
    {
        Debug.Log("Awake");
        TurnSystemReference = GameObject.Find("BattleManager").GetComponent<TurnSystem>();
    }
    public void Act()
    {
        Debug.Log("Attack by " + TurnIndex);
        TurnSystemReference.EndTurn();
    }
}
