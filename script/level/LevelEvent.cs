using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEvent : MonoBehaviour
{
    public GameObject loadingImage;
    public Animator loadingBar;

    public float transitionTime = 7f;

    private LevelManager1 levelManager = new LevelManager1();

    public void LevelEasy(int currentLevel) {
        levelManager.currentEasyLevel = currentLevel;
        Debug.Log("selecting easy level: " + currentLevel.ToString());

        StartCoroutine(loadingScene("easy-level"));
    }

    public void LevelMedium(int currentLevel)
    {
        levelManager.currentMediumLevel = currentLevel;
        Debug.Log("selecting medium level: " + currentLevel.ToString());

        StartCoroutine(loadingScene("medium-level"));
    }

    public void LevelHard(int currentLevel)
    {
        levelManager.currentHardLevel = currentLevel;
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
