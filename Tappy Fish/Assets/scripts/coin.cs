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
   

    private void OnTriggerEnter2D(Collider2D collision) // bal���n ne ile �arp��t���n� kontrol edecek.
    {

        // Debug.Log("collision" + GameManger.gameOver); //burdan itibaren bal���n �lmesi i�in.

        if (collision.CompareTag("fish") && GameManger.gameOver == false)
        {
            Destroy(gameObject); //bal�k coline de�ince colini sil
            GoldManager.goldManager.Goldcoind();
        }

    }
   
}





