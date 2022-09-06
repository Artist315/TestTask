using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public DeviceState CurrentState;
    public void Initialize(DeviceState startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }

    public void ChangeState(DeviceState newState)
    {
        CurrentState.Exit();

        CurrentState = newState;
        newState.Enter();
    }
}
