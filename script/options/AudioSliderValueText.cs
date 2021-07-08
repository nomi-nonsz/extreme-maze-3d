using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSliderValueText : MonoBehaviour
{
    public Slider slider;
    public Text sliderText;

    // Update is called once per frame
    void Update()
    {
        if (slider.value == 0)
            sliderText.text = "SFX (off)";
        else
            sliderText.text = "SFX";
    }
}
