using System;
using UnityEngine;

public class AnalogDeviceObject : DeviceObject
{
    [SerializeField] public float a1;
    [SerializeField] public float a2;
    private void Awake()
    {
        _device = new AnalogDevice(a1,a2);
        _device.StartMove += ContiniousMoveToPosition;
    }

    private void ContiniousMoveToPosition(object sender, Vector3 pos)
    {
        if (_device.IsOutOfReachZone(Vector3.zero, pos))
        {
            Debug.LogWarning("Target out of Zone");
            return;
        }
        Debug.Log("StartMove");

        EndPoint.transform.position = Part_a1.transform.position + pos;

        RotateBase(EndPoint.transform.position);
        RotateJoints(EndPoint.transform.position);
    }

    private void OnDestroy()
    {
        _device.StartMove -= ContiniousMoveToPosition;
    }

    private void RotateBase(Vector3 EndPointPos)
    {
        Base.transform.LookAt(new Vector3(EndPointPos.x, Base.transform.position.y, EndPointPos.z));
    }

    //private void CalculateAngles(Vector3 EndPointPos)
    //{
    //    var q2 = _device.CalculateQ2(Base.transform.position, EndPointPos);
    //    var q1 = _device.CalculateQ1(Base.transform.position, EndPointPos, q2);
    //    var eulerAngle = q1 / (float)Math.PI * 180 > 0 ? q1 / (float)Math.PI * 180 : 180 + q1 / (float)Math.PI * 180;
    //    Part_a1.transform.eulerAngles = new Vector3(90 - eulerAngle, Part_a1.transform.rotation.eulerAngles.y, Part_a1.transform.rotation.eulerAngles.z);
    //    Part_a2.transform.position = Part_a1.GetComponentInChildren<Part>().ConnectionPoint.transform.position;
    //    Part_a2.transform.LookAt(EndPointPos);

    //}
}
