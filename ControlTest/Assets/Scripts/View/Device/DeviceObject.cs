using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceObject : MonoBehaviour
{
    [SerializeField] public GameObject EndPoint;
    [SerializeField] public GameObject Base;

    [SerializeField] public GameObject Part_a1;
    [SerializeField] public GameObject Part_a2;

    [SerializeField] public string Id;

    [SerializeField] public string Name;
    [SerializeField] public ErrorBehaviorEnum ErrorBehavior = ErrorBehaviorEnum.BreakAction;


    internal bool isMooving = false;
    internal Device _device;

    public void Start()
    {
        AttachEndPointToConnector();
    }

    //public StateMachine SM;
    //public MovingState movingState;
    //public IdlingState idlingState;

    //private void Start()
    //{
    //    SM = new StateMachine();

    //    movingState = new MovingState(SM, this);
    //    idlingState = new IdlingState(SM, this);  

    //    SM.Initialize(idlingState);
    //}
    public virtual void Move(Vector3 postionTo, DeviceType deviceType)
    {
        throw new NotImplementedException();
    }

    internal virtual void RotateJoints(Vector3 EndPointPos)
    {
        var q2 = _device.CalculateQ2(Base.transform.position, EndPointPos);
        var q1 = _device.CalculateQ1(Base.transform.position, EndPointPos, q2);
        var eulerAngle = q1 / (float)Math.PI * 180 > 0 ? q1 / (float)Math.PI * 180 : 180 + q1 / (float)Math.PI * 180;
        Part_a1.transform.eulerAngles = new Vector3(90 - eulerAngle, Part_a1.transform.rotation.eulerAngles.y, Part_a1.transform.rotation.eulerAngles.z);
        Part_a2.transform.position = Part_a1.GetComponentInChildren<Part>().ConnectionPoint.transform.position;
        Part_a2.transform.LookAt(EndPointPos);
    }

    internal virtual void AttachEndPointToConnector()
    {
        EndPoint.transform.position = Part_a2.GetComponentInChildren<Part>().ConnectionPoint.transform.position;
    }

    #region Collisions And Triggers
    public virtual void OnCollisionEnter(Collision collision)
    {
        Debug.LogWarning($"Collision on object with name {Name}");
        switch (ErrorBehavior)
        {
            case ErrorBehaviorEnum.Unknown:
                break;
            case ErrorBehaviorEnum.BreakAction:
                Debug.LogWarning($"Collision on object with name {Name}");
                isMooving = false;
                AttachEndPointToConnector();
                break;
            case ErrorBehaviorEnum.ThrowError:
                throw new Exception($"Collision on object with name {Name}");
            case ErrorBehaviorEnum.ContinueAction:
                Debug.LogWarning($"Collision on object with name {Name}");
                break;
            default:
                break;
        }
    }

    public virtual void OnCollisionStay(Collision collision)
    {
        Debug.LogWarning($"Collision on object with name {Name}");
        switch (ErrorBehavior)
        {
            case ErrorBehaviorEnum.Unknown:
                break;
            case ErrorBehaviorEnum.BreakAction:
                Debug.LogWarning($"Collision on object with name {Name}");
                isMooving = false;
                AttachEndPointToConnector();
                break;
            case ErrorBehaviorEnum.ThrowError:
                throw new Exception($"Collision on object with name {Name}");
            case ErrorBehaviorEnum.ContinueAction:
                Debug.LogWarning($"Collision on object with name {Name}");
                break;
            default:
                break;
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    switch (ErrorBehavior)
    //    {
    //        case ErrorBehaviorEnum.Unknown:
    //            break;
    //        case ErrorBehaviorEnum.BreakAction:
    //            Debug.LogWarning($"Trigger on object with name {Name}");
    //            isMooving = false;
    //            AttachEndPointToConnector();
    //            break;
    //        case ErrorBehaviorEnum.ThrowError:
    //            throw new Exception($"Trigger on object with name {Name}");
    //        case ErrorBehaviorEnum.ContinueAction:
    //            Debug.LogWarning($"Trigger on object with name {Name}");
    //            break;
    //        default:
    //            break;
    //    }
    //}
    //private void OnTriggerStay(Collider other)
    //{
    //    switch (ErrorBehavior)
    //    {
    //        case ErrorBehaviorEnum.Unknown:
    //            break;
    //        case ErrorBehaviorEnum.BreakAction:
    //            Debug.LogWarning($"Trigger on object with name {Name}");
    //            isMooving = false;
    //            AttachEndPointToConnector();
    //            break;
    //        case ErrorBehaviorEnum.ThrowError:
    //            throw new Exception($"Trigger on object with name {Name}");
    //        case ErrorBehaviorEnum.ContinueAction:
    //            Debug.LogWarning($"Trigger on object with name {Name}");
    //            break;
    //        default:
    //            break;
    //    }
    //}
    #endregion
}
    