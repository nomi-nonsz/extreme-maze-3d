using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class timeOutButton : MonoBehaviour
{
    [Header("Animator")]
    public Animator transition;
    public float transitionTime = 0.2f;

    [Header("Audio SFX")]
    public AudioSource sfx;
    public AudioClip sound;

    [Range(0f, 1f)]
    public float audioVolume;

    public void RestartButton()
    {
        sfx.volume = audioVolume;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        sfx.PlayOneShot(sound);
        CoinText.coins = 0;
        setTimeOut.timeStart = 120;

        Time.timeScale = 1;
    }
    public void QuitButton()
    {
        sfx.volume = audioVolume;

        sfx.PlayOneShot(sound);
        Time.timeScale = 1;
        StartCoroutine(QuitLevel());
    }

    IEnumerator QuitLevel()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Level-Easy");

        CoinText.coins = 0;
        setTimeOut.timeStart = 120;
    }
}
