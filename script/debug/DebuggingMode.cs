using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuggingMode : MonoBehaviour
{
    public GameObject debugObj;
    public bool isDebugMode;

    private void Start()
    {
        debugObj.SetActive(isDebugMode);
    }
}
