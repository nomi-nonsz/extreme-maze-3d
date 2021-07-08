using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTransition : MonoBehaviour
{
	public Animator transition;

	public float transitionTime = 1f;

    public void LoadPlay() {
    	StartCoroutine(LoadScenePlay());
    }

    public void LoadOptions() {
        StartCoroutine(LoadSceneOptions());
    }

    public void LoadCredits() {
        StartCoroutine(LoadSceneCredits());
    }

    public void QuitGame() {
        StartCoroutine(QuitSceneLoad());
    }

    IEnumerator LoadScenePlay() {
    	transition.SetTrigger("Start");

    	yield return new WaitForSeconds(transitionTime);

    	SceneManager.LoadScene("Difficulty-Select");
    }

    IEnumerator LoadSceneOptions() {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("Options");
    }

    IEnumerator LoadSceneCredits() {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("Credits");
    }

    IEnumerator QuitSceneLoad() {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        Application.Quit();
    }
}