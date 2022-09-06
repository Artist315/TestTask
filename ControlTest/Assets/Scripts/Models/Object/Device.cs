using System;
using UnityEngine;

public class Device : IMovable
{
    public event EventHandler<Vector3> StartMove;
    public float A1 { get; private set; }
    public float A2 { get; private set; }
    public Vector3 State { get; set; }
    public Guid Id { get; set; }
    public float Speed { get; private set; }
    public DeviceLimits Limits { get; private set; } = new DeviceLimits();

    public Device(float a1, float a2)
    {
        A1 = a1;
        A2 = a2;
    }
    public virtual void Move(Vector3 position)
    {
        StartMove.Invoke(this, position);
    }

    public virtual float CalculateQ1(Vector3 basePosition, Vector3 endPointPos, float q2)
    {
        var y = endPointPos.y - basePosition.y;
        var dist = Vector3.Distance(endPointPos, basePosition);
        var x = Mathf.Sqrt(dist * dist - y * y);
        return Mathf.Atan(y / x) - Mathf.Atan(A2 * Mathf.Sin(q2) / (A1 + A2 * Mathf.Cos(q2)));// rad
    }

    public virtual float CalculateQ2(Vector3 basePosition, Vector3 endPointPos)
    {
        var y = endPointPos.y - basePosition.y;
        var dist = Vector3.Distance(endPointPos, basePosition);
        var x = Mathf.Sqrt(dist * dist - y * y);
        var q2 = -Mathf.Acos((x * x + y * y - A1 * A1 - A2 * A2) / (2 * A1 * A2)); // rad
        return q2;
    }
    public virtual int FindDirection(Vector3 basePosition, Vector3 a1EndPos, Vector3 endPointPos)
    {
        if (Mathf.Sin((a1EndPos.y - basePosition.y) / Vector3.Distance(basePosition, a1EndPos)) > Mathf.Sin((endPointPos.y - basePosition.y) / Vector3.Distance(basePosition, endPointPos)))
        {
            return -1;
        }
        return 1;
    }
    public virtual bool IsOutOfReachZone(Vector3 basePosition, Vector3 endPointPos)
    {
        if (Vector3.Distance(basePosition, endPointPos) > A1+A2)
        {
            return true;
        }
        return false;
    }

}
