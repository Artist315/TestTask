using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlingState : DeviceState
{
    private readonly DeviceObject _device;
    public IdlingState(StateMachine stateMachine, DeviceObject device) : base(stateMachine)
    {
        _device = device;
    }
}
