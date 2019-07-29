using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    private enum State
    {
        Awaiting,
        Busy,
    }
    State state;
    
    void Start()
    {
        state = State.Awaiting;
    }

    
    void Update()
    {

    }
}
