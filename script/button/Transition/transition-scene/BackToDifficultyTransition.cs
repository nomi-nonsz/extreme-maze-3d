using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToDifficultyTransition : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 0.5f;

    public void LoadDifficultySelect()
    {
        StartCoroutine(LoadSceneDifficulty());
    }

    IEnumerator LoadSceneDifficulty()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("Difficulty-Select");
    }
}
