using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    public Text coinText;

    public static int coins = 0;

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + coins;
    }
}
