using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StartButton : MonoBehaviour, IPointerDownHandler
{
    public Animator transition;

    public AudioSource audioSource;
    public AudioClip clickSound;

    LoadOptionsData loadOptions;

    public bool isStart = false;
    public float transitionTime = 1f;
    public float audioSound;

    void Start()
    {
        GameObject gameObject = new GameObject();

        loadOptions = gameObject.AddComponent<LoadOptionsData>();

        audioSound = loadOptions.volumeSfx;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isStart)
        {
            audioSource.volume = audioSound;
            audioSource.PlayOneShot(clickSound);

            StartCoroutine(StartGame());
        }
    }



	//start the game
    IEnumerator StartGame() {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
    	SceneManager.LoadScene("Menu");
    }
}
