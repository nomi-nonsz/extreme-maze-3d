using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEvent : MonoBehaviour
{
    [Header("Unlocked Level")]
    public GameObject[] unlockLevel;

    [Header("Locked Level")]
    public GameObject[] lockedLevel;

    public GameObject loadingImage;
    public Animator loadingBar;

    // waktu transisi
    public float transitionTime = 7f;

    public Level level;

    // kalo 1 berarti EZ kalo 2 berarti medium kalo 3 berarti hard
    public int LevelDiff = 1;
    void OnEnable()
    {
        // ganti level muncul atau kaga
        switch (LevelDiff)
        {
            case 1: LevelObject(lockedLevel, unlockLevel, lockedLevel.Length, level.easy+1); break;
            case 2: LevelObject(lockedLevel, unlockLevel, lockedLevel.Length, level.medium+1); break;
            case 3: LevelObject(lockedLevel, unlockLevel, lockedLevel.Length, level.hard+1); break;
            default: Debug.LogError("Level Difficult only 1-3 values will selected"); break;
        }
    }

    // ganti level muncul atau kaga
    private void LevelObject(GameObject[] lockObj, GameObject[] unlockObj, int levelLength, int currentLevel)
    {
        // bool dikunci atau pun tidak di level
        bool isUnlocked = true;
        bool isLocked = false;

        // pilih level yang gk dikunci
        for (int i = 0; i < levelLength; i++)
        {
            for (int b = 0; b < currentLevel; b++)
            {
                // ubah set active untuk yang dikunci maupun tidak
                unlockObj[b].SetActive(isUnlocked);
                lockObj[b].SetActive(isLocked);
            }
        }

        // pesan debug
        Debug.Log("level unclocked: " + level.easy.ToString());
    }

    // ubah value level ketika masuk level
    public void LevelEasy(int currentLevel)
    {
        LevelManager1.currentEasyLevel = currentLevel;
        Debug.Log("selecting easy level: " + currentLevel.ToString());

        StartCoroutine(loadingScene("easy-level"));
    }

    // ubah value level ketika masuk level
    public void LevelMedium(int currentLevel)
    {
        LevelManager1.currentMediumLevel = currentLevel;
        Debug.Log("selecting medium level: " + currentLevel.ToString());

        StartCoroutine(loadingScene("medium-level"));
    }

    // ubah value level ketika masuk level
    public void LevelHard(int currentLevel)
    {
        LevelManager1.currentHardLevel = currentLevel;
        Debug.Log("selecting hard level: " + currentLevel.ToString());

        StartCoroutine(loadingScene("hard-level"));
    }

    // loading scene
    IEnumerator loadingScene(string scene)
    {
        loadingImage.SetActive(true);
        loadingBar.SetTrigger("Loading");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(scene);
    }
}
