using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControllerButtonPlayer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Color normalColor;
    public Color pressedColor;

    private Image inputImage;

    private bool isPressed = false;

    private void Start()
    {
        inputImage = gameObject.GetComponent<Image>();

        if (!inputImage)
            inputImage = gameObject.AddComponent<Image>();
    }

    private void Update()
    {
        if (isPressed)
            inputImage.color = pressedColor;
        else
            inputImage.color = normalColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
