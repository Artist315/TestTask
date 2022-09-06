using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState :DeviceState
{
    
    private Vector3 target;
    private readonly DeviceObject _device;
    public MovingState(StateMachine stateMachine, DeviceObject device) : base(stateMachine)
    {
        _device = device;
    }

    //public override void PhysicsUpdate()
    //{
    //    var dest = Vector3.MoveTowards(_device.EndPoint.transform.position, target, 0.01f);
    //    _device.EndPoint.transform.position = dest;
    //    RotateBase(dest);
    //    CalculateAngles(dest);
    //}

    //public virtual void Move(Vector3 postionTo, DeviceType deviceType)
    //{
    //    RotateBase(postionTo);
    //}

    //internal void RotateBase(Vector3 EndPointPos)
    //{
    //    Base.transform.LookAt(new Vector3(EndPointPos.x, _device.Base.transform.position.y, EndPointPos.z));
    //}

    //internal void CalculateAngles(Vector3 EndPointPos)
    //{
    //    var y = EndPointPos.y - _device.Base.transform.position.y;
    //    var dist = Vector3.Distance(EndPointPos, _device.Base.transform.position);
    //    var x = Mathf.Sqrt(dist * dist - y * y);
    //    var q2 = Mathf.Acos((x * x + y * y - a1 * a1 - a2 * a2) / (2 * a1 * a2)); // rad


    //    var q1 = Mathf.Atan(y / x) - Mathf.Atan(a2 * Mathf.Sin(q2) / (a1 + a2 * Mathf.Cos(q2)));// rad
    //    Debug.Log($"X:{x}, Y:{y}, Q1: {q1}, Q2: {q2}");
    //    Debug.Log(new Vector3(q1 / (float)Math.PI * 180, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
    //    Part_a1.transform.eulerAngles = new Vector3(q1 / (float)Math.PI * 180, Part_a1.transform.rotation.eulerAngles.y, Part_a1.transform.rotation.eulerAngles.z);
    //}
}
