using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlesPosition : MonoBehaviour
{
    public Transform targetObject;

    void Awake()
    {
        transform.position = targetObject.position;
    }
}
