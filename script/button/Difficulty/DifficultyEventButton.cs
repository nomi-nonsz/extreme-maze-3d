using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyEventButton : MonoBehaviour
{
    public void LevelEasyButton() {
    	SceneManager.LoadScene("Level-Easy");
    }

    public void LevelMediumButton() {
    	SceneManager.LoadScene("Level-Medium");
    }

    public void LevelHardButton() {
    	SceneManager.LoadScene("Level-Hard");
    }
}
