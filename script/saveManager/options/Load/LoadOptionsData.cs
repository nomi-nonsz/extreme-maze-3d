using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadOptionsData : MonoBehaviour
{
    public float volumeSfx;

    public Options options = new Options();

    // Start is called before the first frame update
    void OnEnable()
    {
        LoadOptionsDat();
    }

    public void LoadOptionsDat()
    {
        options = JsonUtility.FromJson<Options>(File.ReadAllText(Application.persistentDataPath + "/options.json"));

        volumeSfx = options.volumeSfx;

        if (File.Exists(Application.persistentDataPath + "/options.json"))
            Debug.Log("File On " + Application.persistentDataPath + "/options" + " has been loaded");
        else
            Debug.LogError("File On " + Application.persistentDataPath + "/options" + " failed to loaded");
    }
}
