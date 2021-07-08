using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{
	public string sceneLoadStart;
	public string triggerName;

	public Animator transition;
	public float transitionTime = 6f;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel() {
    	transition.SetTrigger(triggerName);

    	yield return new WaitForSeconds(transitionTime);

    	SceneManager.LoadScene(sceneLoadStart);
    }
}
