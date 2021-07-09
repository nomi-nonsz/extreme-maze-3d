using UnityEngine;
using UnityEngine.UI;

public class changeCreditsAndDev : MonoBehaviour
{
    public GameObject[] creditsGroup;
    public GameObject[] devGroup;

    public Text textTitle;

    public void selectCredits()
    {
        textTitle.text = "Credits";

        for (int i = 0; i < creditsGroup.Length; i++)
        {
            creditsGroup[i].SetActive(true);
        }

        for (int i = 0; i < devGroup.Length; i++)
        {
            devGroup[i].SetActive(false);
        }
    }

    public void selectDev()
    {
        textTitle.text = "About";

        for (int i = 0; i < creditsGroup.Length; i++)
        {
            creditsGroup[i].SetActive(false);
        }

        for (int i = 0; i < devGroup.Length; i++)
        {
            devGroup[i].SetActive(true);
        }
    }
}
