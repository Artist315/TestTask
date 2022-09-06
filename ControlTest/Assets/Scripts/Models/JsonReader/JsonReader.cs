using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectDeviceInitializer;

public class JsonReader
{
    public void ReadInitJson(string path)
    {
        var objectList = JsonUtility.FromJson<DeviceListData>(path).deviceDataList;
        foreach (var _object in objectList)
        {
            ObjectDeviceInitializer.Instance.StartMove(_object.Name, _object.X, _object.Y, _object.Z);
        }
    }

    public void ReadCreateJson(string path)
    {
        var createObjectList = JsonUtility.FromJson<CreateDeviceListData>(path);
        foreach (var _object in createObjectList.deviceDataList)
        {
            ObjectDeviceInitializer.Instance.InstantiateNewDevice(_object);
        }
    }
}
