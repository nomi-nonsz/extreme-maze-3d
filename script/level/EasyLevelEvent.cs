using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EasyLevelEvent : MonoBehaviour
{
    public GameObject loadingImage;
    public Animator loadingBar;

    public float transitionTime = 7f;

    public void Level1() {
        StartCoroutine(loadingScene("easy-level"));
    }

    IEnumerator loadingScene(string scene)
    {
        loadingImage.SetActive(true);
        loadingBar.SetTrigger("Loading");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(scene);
    }
}
