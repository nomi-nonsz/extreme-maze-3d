using UnityEngine.Audio;
using UnityEngine;

public class ButtonClickAudio : MonoBehaviour
{
    public AudioSource sfx;
    public AudioClip sounds;

    LoadOptionsData loadOptions;

	public float volumeAudio;

    void Start()
    {
        GameObject gameObject = new GameObject();

        loadOptions = gameObject.AddComponent<LoadOptionsData>();

        volumeAudio = loadOptions.volumeSfx;
    }

    public void ClickedSound()
    {
        sfx.volume = volumeAudio;

        sfx.PlayOneShot(sounds);
    }
}
