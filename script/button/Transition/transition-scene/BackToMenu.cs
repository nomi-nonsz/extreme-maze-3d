using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public Animator transition;

	public float transitionTime = 0.5f;

    public void LoadToMenu() {
		StartCoroutine(SceneMenu());
	}

	IEnumerator SceneMenu() {
    	transition.SetTrigger("Start");

    	yield return new WaitForSeconds(transitionTime);

    	SceneManager.LoadScene("Menu");
    }
}
