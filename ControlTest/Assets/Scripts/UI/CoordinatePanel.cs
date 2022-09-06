using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoordinatePanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField X;
    [SerializeField] private TMP_InputField Y;
    [SerializeField] private TMP_InputField Z;

    [SerializeField] private TMP_Dropdown dropdownMenu;
    public void StartMove()
    {
        float x = float.Parse(X.text);
        float y = float.Parse(Y.text.ToString());
        float z = float.Parse(Z.text.ToString());
        ObjectDeviceInitializer.Instance.StartMove(dropdownMenu.options[dropdownMenu.value].text, new Vector3(x, y, z));
    }
}
