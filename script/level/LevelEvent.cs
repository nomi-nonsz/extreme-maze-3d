using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEvent : MonoBehaviour
{
    public GameObject loadingImage;
    public Animator loadingBar;

    public float transitionTime = 7f;

    public void LevelEasy(int currentLevel) {
        LevelManager1.currentEasyLevel = currentLevel;
        Debug.Log("selecting easy level: " + currentLevel.ToString());

        StartCoroutine(loadingScene("easy-level"));
    }

    public void LevelMedium(int currentLevel)
    {
        LevelManager1.currentMediumLevel = currentLevel;
        Debug.Log("selecting medium level: " + currentLevel.ToString());

        StartCoroutine(loadingScene("medium-level"));
    }

    public void LevelHard(int currentLevel)
    {
        LevelManager1.currentHardLevel = currentLevel;
        Debug.Log("selecting hard level: " + currentLevel.ToString());

        StartCoroutine(loadingScene("hard-level"));
    }

    IEnumerator loadingScene(string scene)
    {
        loadingImage.SetActive(true);
        loadingBar.SetTrigger("Loading");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(scene);
    }
}
