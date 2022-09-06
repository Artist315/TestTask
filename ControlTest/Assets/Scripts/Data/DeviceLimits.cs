using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceLimits
{
    public DeviceLimits(float minX = -5, float minY = 0, float minZ = -5, float maxX = 5, float maxY = 5, float maxZ = 5)
    {
        MinX = minX;
        MinY = minY;
        MaxX = maxX;
        MaxY = maxY;
        MaxZ = maxZ;
        MinZ = minZ;
    }
    public float MinX { get; private set; }
    public float MinY { get; private set; }
    public float MinZ { get; private set; }
    public float MaxX { get; private set; }
    public float MaxY { get; private set; }
    public float MaxZ { get; private set; }
}
