using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCoinAnimation : MonoBehaviour
{
    public Vector3 Angel;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Angel * Time.deltaTime);
    }
}
