using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurnSystem : MonoBehaviour
{
    public enum State
    {
        Awaiting,
        Busy,
    }
    public event EventHandler PlayerTurnEnded;


    public State state;
    
    void Start()
    {
        state = State.Awaiting;
    }

    public void EndPlayerTurn()
    {
        state = State.Busy;
        if (PlayerTurnEnded != null) PlayerTurnEnded(this, EventArgs.Empty);
    }
    public void EndEnemyTurn()
    {
        state = State.Awaiting;
    }
}
