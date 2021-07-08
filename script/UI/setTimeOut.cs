using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setTimeOut : MonoBehaviour
{
    public Animator anim;
    public float animTime = 0.2f;

    public static float timeStart = 120f;
    public Text timeText;

    bool timerActive = true;

    // Start is called before the first frame update
    void Start()
    {
        timeText.text = "Time: " + timeStart;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive == true)
        {
            if(timeStart <= 0f)
            {
                timerActive = false;

                StartCoroutine(TimeOut());
            }
            else
            {
                timeStart -= Time.deltaTime;
                timeText.text = "Time: " + timeStart.ToString("F1");
            }
        }
        
    }

    IEnumerator TimeOut()
    {
        anim.SetTrigger("Poin");
        yield return new WaitForSeconds(animTime);
        Time.timeScale = 0;
    }
}
