using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonReaderObject : MonoBehaviour
{

    public TextAsset jsonInitFile;
    public TextAsset jsonCreateFile;
    private JsonReader jsonReader;
    // Start is called before the first frame update
    void Start()
    {
        jsonReader = new JsonReader();
        if (!jsonCreateFile)
        {
            Debug.LogWarning("Attach jsonCreate path");
        }
        if (!jsonInitFile)
        {
            Debug.LogWarning("Attach jsonInit path");
        }
    }

    public void ReadInitJson()
    {
        jsonReader.ReadInitJson(jsonInitFile.text);
    }

    public void ReadCreateJson()
    {
        jsonReader.ReadCreateJson(jsonCreateFile.text);
    }
}
