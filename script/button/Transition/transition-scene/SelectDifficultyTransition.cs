using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectDifficultyTransition : MonoBehaviour
{
    public Animator transition;

    public string toSceneEasy;
    public string toSceneMedium;
    public string toSceneHard;

    public float transitionTime = 0.5f;

    public void LoadEasy()
    {
        StartCoroutine(LoadSceneEasy());
    }

    public void LoadMedium()
    {
        StartCoroutine(LoadSceneMedium());
    }
    public void LoadHard()
    {
        StartCoroutine(LoadSceneHard());
    }

    IEnumerator LoadSceneEasy()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(toSceneEasy);
    }

    IEnumerator LoadSceneMedium()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(toSceneMedium);
    }

    IEnumerator LoadSceneHard()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(toSceneHard);
    }
}
