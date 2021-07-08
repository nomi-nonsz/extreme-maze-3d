using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugSystem : MonoBehaviour
{
    public string optionDebug = "[options]";
    public string gameDebug = "[game]";
    public string uiDebug = "[ui]";
    public string volumeDebug = "[volume]";
    public string saveSystemDat = "[saveSystem]";

    public static string currentScene(string scn)
    {
        string isScn = "[scene:" + scn + "]";
        return isScn;
    }
}
