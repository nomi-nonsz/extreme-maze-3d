using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseButton : MonoBehaviour
{
    public GameObject pauseUI;

    [Header("Animator")]
    public Animator transition;
    public float transitionTime = 0.2f;

    [Header("Audio SFX")]
    public AudioSource sfx;
    public AudioClip sound;

    [Range(0f, 1f)]
    public float audioVolume;

    void Update()
    {
        sfx.volume = audioVolume;
    }

    public void resumeButton()
    {
        sfx.PlayOneShot(sound);
        pause.pauseGame = false;

        pauseUI.SetActive(false);
        Time.timeScale = 1;
        
    }

    public void restartButton()
    {
        sfx.PlayOneShot(sound);
        pause.pauseGame = false;
        Time.timeScale = 1;

        StartCoroutine(restartAnim());
    }

    public void quitButton()
    {
        sfx.PlayOneShot(sound);
        pause.pauseGame = false;
        Time.timeScale = 1;

        StartCoroutine(quitAnim());
    }

    IEnumerator restartAnim()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        pauseUI.SetActive(false);
        setTimeOut.timeStart = 120;
        CoinText.coins = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator quitAnim()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        pauseUI.SetActive(false);
        setTimeOut.timeStart = 120;
        CoinText.coins = 0;
        SceneManager.LoadScene("Level-Easy");
    }
}