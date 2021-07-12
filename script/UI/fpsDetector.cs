using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fpsDetector : MonoBehaviour
{
    public Text fpsText;
    public GameObject fpsObject;

    public float fpsDelay = 1f;

    private float fps;

    DebugSystem debug;
    LoadOptionInLevel options;

    void Start()
    {
        GameObject gameObject = new GameObject();

        debug = gameObject.AddComponent<DebugSystem>();
        options = gameObject.AddComponent<LoadOptionInLevel>();

        fpsObject.SetActive(options.isFps);

        if (options.isFps)
            Debug.Log(debug.gameDebug + debug.uiDebug + "FPS Displayed");
        else
            Debug.Log(debug.gameDebug + debug.uiDebug + "FPS Hidden");

        StartCoroutine(RecalculateFps());
    }

    private IEnumerator RecalculateFps()
    {
        while (true)
        {
            fps = 1 / Time.deltaTime;
            yield return new WaitForSeconds(fpsDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        fpsText.text = "FPS: " + Mathf.Round(fps);
    }
}
