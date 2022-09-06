using System;
using UnityEngine;

public class DeviceInitData 
{
    public Guid Id { get; set; } 
    public Vector3 InitPosition { get; set; }
    public Vector3 Location { get; set; }
    public DeviceType DeviceType { get; set; }
}

public enum DeviceType
{
    Unknown = 0,
    Analog = 1,
    Discrete = 2,
}
