
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Medap : MonoBehaviour
{
    
    public Sprite metalMedap, bronzeMedap, silverMedap, goldMedap; // madalyon deðiþkenleri tanýmlandý.
   Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
        int gameScore = GameManger.gameScore; // game score deðerlerine bakýyoruz.

        if(gameScore>0&& gameScore <= 1)
        {
            img.sprite = metalMedap;
        }else if (gameScore>1&& gameScore<=2)
        {
            img.sprite = bronzeMedap;
        }
        else if (gameScore > 2 && gameScore <= 3)
        {
            img.sprite = silverMedap;
        }
        else if (gameScore>3)
        {
            img.sprite = goldMedap;
        }
    }
}
