using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finshButton : MonoBehaviour
{
    [Header("Animator")]
    public Animator transition;
    public float transitionStart = .2f;

    [Header("Audio")]
    public AudioSource sfx;
    public AudioClip clip;

    public float audioVolume;

    LoadOptionsData loadOptions;

    void Start()
    {
        GameObject gameObject = new GameObject();
        loadOptions = gameObject.AddComponent<LoadOptionsData>();

        audioVolume = loadOptions.volumeSfx;
    }

    public void quitButton()
    {
        sfx.volume = audioVolume;
        sfx.PlayOneShot(clip);
        Time.timeScale = 1;

        StartCoroutine(quitAnim());
    }

    IEnumerator quitAnim()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionStart);
        SceneManager.LoadScene("Level-Easy");

        setTimeOut.timeStart = 120;
        CoinText.coins = 0;
    }
}
