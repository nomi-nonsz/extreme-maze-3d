using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEvent : MonoBehaviour
{
    public GameObject[] levelObj;

    public GameObject loadingImage;
    public Animator loadingBar;

    public float transitionTime = 7f;

    public Color normalColor;
    public Color highlighColor;
    public Color pressedColor;
    public Color selectedColor;

    private Button[] levelButton;

    private Level level = new Level();

    private void OnEnable()
    {
        for (int b = 0; b < level.easy; b++)
        {
            levelButton[b] = levelObj[b].AddComponent<Button>();
            buttonCol(b);
        }
    }

    private void buttonCol(int arr)
    {
        ColorBlock cb = levelButton[arr].colors;

        cb.normalColor = normalColor;
        cb.pressedColor = pressedColor;
        cb.highlightedColor = highlighColor;
        cb.selectedColor = selectedColor;

        levelButton[arr].colors = cb;
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
