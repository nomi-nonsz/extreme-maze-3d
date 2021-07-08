using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEventButton : MonoBehaviour
{
    public void BackToDifficulty() {
    	SceneManager.LoadScene("Difficulty-Select");
    }
}
