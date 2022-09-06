using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DeviceState
{
    protected StateMachine stateMachine;
    public string Name;
    protected DeviceState(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;

    }

    public virtual void Enter()
    {
    }
    public virtual void HandleInput()
    {
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Exit()
    {

    }
}
