using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurnSystem : MonoBehaviour
{
    public enum State
    {
        Player,
        Enemy,
    }
    public event EventHandler PlayerTurnStart;
    public event EventHandler EnemyTurnStart;

    public State state;
    
    void Start()
    {
        state = State.Player;
    }

    public void EndPlayerTurn()
    {
        state = State.Enemy;
        if (EnemyTurnStart != null) EnemyTurnStart(this, EventArgs.Empty);
    }
    public void EndEnemyTurn()
    {
        state = State.Player;
        if (PlayerTurnStart != null) PlayerTurnStart(this, EventArgs.Empty);
    }
}
