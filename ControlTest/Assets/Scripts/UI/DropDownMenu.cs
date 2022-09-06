using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DropDownMenu : MonoBehaviour
{

    [SerializeField] private TMP_Dropdown dropdownMenu;
    private void Awake()
    {
        AttachList();
    }
    public void AttachList()
    {

        dropdownMenu.ClearOptions();
        var devices = ObjectDeviceInitializer.Instance.GetDeviceList();
        Debug.Log($"{devices.Count} options for drop Down");
        dropdownMenu.AddOptions(devices.Select(x => x.Name).ToList());
    }
}
