using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public Text CoinAmonutText;
    public static int CoinAmonut = 0;
    private int goldhighScore = 0;

    public static GoldManager goldManager = null;
    
    void Start()
    {
        goldManager = this;
        CoinAmonut = 0;
        CoinAmonutText = GetComponent<Text>();
        CoinAmonutText.text = $"{CoinAmonut} G";
    }


    public void Goldcoind() // skor altýn sayma olayý
    {
        CoinAmonut++;
        CoinAmonutText.text = $"{CoinAmonut} G";
        if (CoinAmonut > goldhighScore)
        {

            goldhighScore = CoinAmonut;
        }
    }
}
