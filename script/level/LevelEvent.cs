using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEvent : MonoBehaviour
{
    [Header("Unlocked Level")]
    public GameObject unlockLevel1;
    public GameObject unlockLevel2;
    public GameObject unlockLevel3;
    public GameObject unlockLevel4;
    public GameObject unlockLevel5;

    [Header("Locked Level")]
    public GameObject lockLevel1;
    public GameObject lockLevel2;
    public GameObject lockLevel3;
    public GameObject lockLevel4;
    public GameObject lockLevel5;

    public GameObject loadingImage;
    public Animator loadingBar;

    public float transitionTime = 7f;

    public Level level;

    void OnEnable()
    {
        LevelObject();
    }

    private void LevelObject()
    {
        if (level.easy >= 0)
        {
            unlockLevel1.SetActive(true);
            lockLevel1.SetActive(false);
        }
        if (level.easy >= 1)
        {
            unlockLevel2.SetActive(true);
            lockLevel2.SetActive(false);
        }
        if (level.easy >= 2)
        {
            unlockLevel3.SetActive(true);
            lockLevel3.SetActive(false);
        }
        if (level.easy >= 3)
        {
            unlockLevel4.SetActive(true);
            lockLevel4.SetActive(false);
        }
        if (level.easy >= 4)
        {
            unlockLevel5.SetActive(true);
            lockLevel5.SetActive(false);
        }

        Debug.Log("level unclocked: " + level.easy.ToString());
    }

    public void LevelEasy(int currentLevel)
    {
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
