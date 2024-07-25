using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class coin : MonoBehaviour
{
   

    private void OnTriggerEnter2D(Collider2D collision) // balýðýn ne ile çarpýþtýðýný kontrol edecek.
    {

        // Debug.Log("collision" + GameManger.gameOver); //burdan itibaren balýðýn ölmesi için.

        if (collision.CompareTag("fish") && GameManger.gameOver == false)
        {
            Destroy(gameObject); //balýk coline deðince colini sil
            GoldManager.goldManager.Goldcoind();
        }

    }
   
}





