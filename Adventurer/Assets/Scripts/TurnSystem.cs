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
    public event EventHandler PlayerTurnStart;
    public event EventHandler EnemyTurnStart;

    public delegate void TurnCallback (int index);
    public event TurnCallback NewTurn;

    public State state;
    public int index;
    public int BattleEntitiesAmount;
    public int PlayerIndex;

    void Start()
    {
        index = 0;
        state = State.Awaiting; // do usuniecia
    }

    private void PlayerTurnEnded()
    {
        state = State.Busy;
        if (EnemyTurnStart != null) EnemyTurnStart(this, EventArgs.Empty);
    }
    private void PlayerTurnStarted()
    {
        state = State.Awaiting;
        if (PlayerTurnStart != null) PlayerTurnStart(this, EventArgs.Empty);
    }

    public void EndTurn()
    {
        if (index == PlayerIndex) PlayerTurnEnded();
        
        if (index < BattleEntitiesAmount) index++; //iterujemy po uczestnikach walki
        else index = 0;

        if (index == PlayerIndex) PlayerTurnStarted();



        if (NewTurn != null) NewTurn(index); // odpalamy event z parametrem kogo jest tura
    }
}
