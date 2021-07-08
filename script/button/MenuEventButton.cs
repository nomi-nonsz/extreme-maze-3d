using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEventButton : MonoBehaviour
{
    public void PlayButton() {
    	SceneManager.LoadScene("Difficulty-Select");
    }

    public void OptionButton() {
    	SceneManager.LoadScene("Options");
    }

    public void CreditButton() {
    	SceneManager.LoadScene("Credits");
    }

    public void QuitButon() {
    	Application.Quit();
    }

    public void BackButton() {
    	SceneManager.LoadScene("Menu");
    }
}
