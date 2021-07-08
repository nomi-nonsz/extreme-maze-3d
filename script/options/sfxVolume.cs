using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sfxVolume : MonoBehaviour
{
    CoinManager coinAudio;
    ButtonClickAudio btnAudio;

    public Slider volumeSlider;

    void Start()
    {
        GameObject gameObject = new GameObject();

        coinAudio = gameObject.AddComponent<CoinManager>();
        btnAudio = gameObject.AddComponent<ButtonClickAudio>();
    }

    public void changeVolume()
    {
        btnAudio.volumeAudio = volumeSlider.value;
        coinAudio.audioVolume = volumeSlider.value;
    }
}
