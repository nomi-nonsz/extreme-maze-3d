using UnityEngine;
using UnityEngine.Android;
using System.IO;

public class LoadOptionInLevel : MonoBehaviour
{
    public bool isFps;
    public bool isCtrl;
    public bool isBloom;
    public float volumeSfx;

    public int controlMode;

    public Options options = new Options();

    private bool isMobile = false;

    void OnEnable()
    {
#if UNITY_ANDROID
        isMobile = true;
#endif

        LoadOptionsInGame();
    }

    public void LoadOptionsInGame()
    {
        options = JsonUtility.FromJson<Options>(File.ReadAllText(Application.persistentDataPath + "/options.json"));

        if (isMobile)
        {
            isCtrl = false;
            isBloom = false;

            controlMode = options.controlMobile;
        }
        else
        {
            isCtrl = options.setController;
            isBloom = options.setBloom;
        }

        isFps = options.setFPS;
        volumeSfx = options.volumeSfx;

        if (File.Exists(Application.persistentDataPath + "/options.json"))
            Debug.Log("File On " + Application.persistentDataPath + "/options" + " has been loaded");
        else
            Debug.LogError("File On " + Application.persistentDataPath + "/options" + " failed to loaded");
    }
}
