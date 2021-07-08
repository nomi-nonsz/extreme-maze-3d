using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralDebugging : MonoBehaviour
{
    Options options;
    DebugSystem debug;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = new GameObject();

        options = new Options();
        debug = gameObject.AddComponent<DebugSystem>();

        Debug.Log(debug.optionDebug + debug.uiDebug + DebugSystem.currentScene("menu") + " FPS is " + options.setFPS);
    }
}
