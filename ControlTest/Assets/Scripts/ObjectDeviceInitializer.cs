using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class ObjectDeviceInitializer : Singleton<ObjectDeviceInitializer>
{
    [SerializeField] private GameObject _analogDevice;
    [SerializeField] private GameObject _discreteDevice;

    [SerializeField] private List<DeviceObject> existingObjects;

    #region DeviceData
    [System.Serializable]
    public class DeviceData
    {
        public string Name;
        public float X;
        public float Y;
        public float Z;

    }

    [System.Serializable]
    public class DeviceListData
    {
        public DeviceData[] deviceDataList;
    }

    #endregion

    #region CreateDeviceData
    [System.Serializable]
    public class CreateDeviceData
    {
        public string Name;
        public float PosX;
        public float PosY;
        public float PosZ;
        public int Type;
        public int ErrorBehavior;
    }

    [System.Serializable]
    public class CreateDeviceListData
    {
        public CreateDeviceData[] deviceDataList;
    }
    #endregion


    private void Start()
    {
        GetDeviceList();
    }
    public List<DeviceObject> GetDeviceList()
    {
        existingObjects = FindDevices();
        return existingObjects;
    }

    public void StartMove(string name, Vector3 positionTo)
    {
        if (existingObjects.Any(x =>x.Name == name))
        {
            existingObjects.FirstOrDefault(x => x.Name == name)._device.Move(positionTo);
            Debug.Log($"Command to device {name} was send");
        }
        else
            Debug.LogWarning($"No device with name {name} was found");
    }

    public void StartMove(string name, float x, float y, float z)
    {
        if (existingObjects.Any(x => x.Name == name))
        {
            existingObjects.FirstOrDefault(x => x.Name == name)._device.Move(new Vector3(x,y,z));
            Debug.Log($"Command to device {name} was send");
        }
        else
            Debug.LogWarning($"No device with name {name} was found");
    }

    private List<DeviceObject> FindDevices()
    {
        return FindObjectsOfType<DeviceObject>().ToList();
    }

    public void InstantiateNewDevice(CreateDeviceData createRequest)
    {
        var prefab = TakePrefab((DeviceType)createRequest.Type);
        if (!prefab)
        {
            throw new Exception("No prefab for such device type");
        }
        if (existingObjects.Any(x => x.Name == createRequest.Name))
        {
            throw new Exception("Name of created object must be unique");
        }

        Vector3 initPosition = new Vector3(createRequest.PosX, createRequest.PosY, createRequest.PosZ);
        var _object = Instantiate(prefab, initPosition, Quaternion.Euler(0, 0, 0));
        var device = _object.GetComponent<DeviceObject>();
        device.Name = createRequest.Name;
        Debug.Log($"Add Object with name {createRequest.Name} with {initPosition} position");

        GetDeviceList();
    }

    private GameObject TakePrefab(DeviceType deviceType)
    {
        switch (deviceType)
        {
            case DeviceType.Unknown:
                break;
            case DeviceType.Analog:
                return _analogDevice;
            case DeviceType.Discrete:
                return _discreteDevice;
            default:
                break;
        }
        return null;
    }
}
