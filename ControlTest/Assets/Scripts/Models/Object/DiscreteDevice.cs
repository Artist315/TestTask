using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscreteDevice : Device
{
    public DiscreteDevice(float a1, float a2) : base(a1, a2)
    {
    }
    public DeviceType DeviceType { get; private set; }
}
