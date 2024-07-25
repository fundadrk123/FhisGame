using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class denemescore : MonoBehaviour
{
    

    public Text denemeText;
    public static int denemescor = 0;
    private int denemehighScore = 0;

    public static denemescore Denemescore = null;

    void Start()
    {
        Denemescore = this;
        denemescor = 0;
        denemeText = GetComponent<Text>();
        denemeText.text = $"{denemescor}";
    }

    public void Deneme() // skor altýn sayma olayý
    {
        denemescor++;
        denemeText.text = $"{denemescor}";
        if (denemescor > denemehighScore)
        {
            denemehighScore =denemescor;
        }
    }

   
}
