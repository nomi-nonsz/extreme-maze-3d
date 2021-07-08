using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDebug : MonoBehaviour
{
    public string version;

    void Start()
    {
        Debug.Log("Extreme Maze 3D " + version + "\nif you find a bug please report us");
    }
}
