using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorescore : MonoBehaviour
{
   

    private void OnTriggerEnter2D(Collider2D collision) 
    {

        if (collision.CompareTag("fish") && GameManger.gameOver == false)
        {
            Destroy(gameObject);
            denemescore.Denemescore.Deneme();
        }

    }

}
