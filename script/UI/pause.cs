using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public static bool pauseGame = false;

    public GameObject pauseUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            if(pauseGame)
            {
                pauseUI.SetActive(false);
                Time.timeScale = 1;
                pauseGame = false;
            }
            else
            {
                pauseUI.SetActive(true);
                Time.timeScale = 0;
                pauseGame = true;
            }
        }
    }
}
