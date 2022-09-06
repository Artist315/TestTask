using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalogDevice : Device
{
    public AnalogDevice(float a1, float a2) : base(a1, a2)
    {
    }
    public DeviceType DeviceType { get; private set; }
}
