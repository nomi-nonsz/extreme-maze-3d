using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotoUrl : MonoBehaviour
{
    public void toTheUrl(string devUrl)
    {
        Application.OpenURL(devUrl);
    }
}
