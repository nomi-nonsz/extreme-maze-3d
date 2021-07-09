using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logoImagesRotation : MonoBehaviour
{
    public float rotateSpeed;

    void Start()
    {

    }

    public void isRotating(bool onRotating)
    {
        if (onRotating)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 180), rotateSpeed);
            rotateSpeed = rotateSpeed * Time.deltaTime;
        }
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
