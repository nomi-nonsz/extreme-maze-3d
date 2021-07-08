using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NavigationButton : MonoBehaviour
{
    [Header("Button")]
    public Button generalButton;
    public Button volumeButton;
    public Button graphicsButton;

    [Header("Button Object")]
    public GameObject generalContent;
    public GameObject volumeContent;
    public GameObject graphicsContent;

    [Header("Button Color")]
    public Color defaultColor;
    public Color selectColor;

    [Header("SetActive Button Booleans")]
    public bool isGeneral = true;
    public bool isVolume = false;
    public bool isGraphics = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        ColorBlock cbGeneral = generalButton.colors;
        ColorBlock cbVolume = volumeButton.colors;
        ColorBlock cbGraphics = graphicsButton.colors;

        generalContent.SetActive(isGeneral);
        volumeContent.SetActive(isVolume);
        graphicsContent.SetActive(isGraphics);

        if (isGeneral)
        {
            cbGeneral.normalColor = selectColor;
            cbGeneral.highlightedColor = selectColor;
            cbGeneral.pressedColor = selectColor;
            cbGeneral.selectedColor = selectColor;
            cbGeneral.disabledColor = selectColor;

            cbVolume.normalColor = defaultColor;
            cbVolume.highlightedColor = defaultColor;
            cbVolume.pressedColor = defaultColor;
            cbVolume.selectedColor = defaultColor;
            cbVolume.disabledColor = defaultColor;

            cbGraphics.normalColor = defaultColor;
            cbGraphics.highlightedColor = defaultColor;
            cbGraphics.pressedColor = defaultColor;
            cbGraphics.selectedColor = defaultColor;
            cbGraphics.disabledColor = defaultColor;
        }
        else if (isVolume)
        {
            cbGeneral.normalColor = defaultColor;
            cbGeneral.highlightedColor = defaultColor;
            cbGeneral.pressedColor = defaultColor;
            cbGeneral.selectedColor = selectColor;
            cbGeneral.disabledColor = selectColor;

            cbVolume.normalColor = selectColor;
            cbVolume.highlightedColor = selectColor;
            cbVolume.pressedColor = selectColor;
            cbVolume.selectedColor = selectColor;
            cbVolume.disabledColor = selectColor;

            cbGraphics.normalColor = defaultColor;
            cbGraphics.highlightedColor = defaultColor;
            cbGraphics.pressedColor = defaultColor;
            cbGraphics.selectedColor = defaultColor;
            cbGraphics.disabledColor = defaultColor;
        }
        else if (isGraphics)
        {
            cbGeneral.normalColor = defaultColor;
            cbGeneral.highlightedColor = defaultColor;
            cbGeneral.pressedColor = defaultColor;
            cbGeneral.selectedColor = selectColor;
            cbGeneral.disabledColor = selectColor;

            cbVolume.normalColor = defaultColor;
            cbVolume.highlightedColor = defaultColor;
            cbVolume.pressedColor = defaultColor;
            cbVolume.selectedColor = defaultColor;
            cbVolume.disabledColor = defaultColor;

            cbGraphics.normalColor = selectColor;
            cbGraphics.highlightedColor = selectColor;
            cbGraphics.pressedColor = selectColor;
            cbGraphics.selectedColor = selectColor;
            cbGraphics.disabledColor = selectColor;
        }

        generalButton.colors = cbGeneral;
        volumeButton.colors = cbVolume;
        graphicsButton.colors = cbGraphics;
    }

    public void selectGeneral()
    {
        isGeneral = true;
        isVolume = false;
        isGraphics = false;
    }

    public void selectVolume()
    {
        isGeneral = false;
        isVolume = true;
        isGraphics = false;
    }

    public void selectGraphics()
    {
        isGeneral = false;
        isVolume = false;
        isGraphics = true;
    }
}
