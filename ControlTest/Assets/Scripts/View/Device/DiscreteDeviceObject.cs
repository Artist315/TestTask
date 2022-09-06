using System;
using UnityEngine;

public class DiscreteDeviceObject : DeviceObject
{
    [SerializeField] public float a1;
    [SerializeField] public float a2;

    private Vector3 target;
    private void Awake()
    {
        _device = new DiscreteDevice(a1,a2);
        _device.StartMove += InstantMoveToPosition;
    }

    private void InstantMoveToPosition(object sender, Vector3 pos)
    {
        Debug.Log("StartMove");
        if (_device.IsOutOfReachZone(Vector3.zero, pos))
        {
            Debug.LogWarning("Target out of Zone");
            return;
        }
        target = Part_a1.transform.position + pos;
        isMooving = true;


    }
    private void Update()
    {
        if (isMooving)
        {
            var dest = Vector3.MoveTowards(EndPoint.transform.position,target, 0.01f);
            EndPoint.transform.position = dest;
            RotateBase(dest);
            RotateJoints(dest);
        }
        if (Vector3.Distance(target, EndPoint.transform.position) <= 0)
        {
            isMooving = false;
        }
    }

    private void OnDestroy()
    {
        _device.StartMove -= InstantMoveToPosition;
    }

    private void RotateBase(Vector3 EndPointPos)
    {
        Base.transform.LookAt(new Vector3(EndPointPos.x, Base.transform.position.y, EndPointPos.z));
    }

    
}
