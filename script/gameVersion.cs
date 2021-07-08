using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameVersion : MonoBehaviour
{
    public Text versionText;
    public string version;

    // Start is called before the first frame update
    void Start()
    {
        versionText.text = "version " + version;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
