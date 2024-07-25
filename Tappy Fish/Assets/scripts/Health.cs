using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class Health : MonoBehaviour
{
    
    public float life, reducespeed; // can ve d���rme h�z�
    private float maxLife,realScale; // maximum can ve ger�ek

    private void Start()
    {
        maxLife = life; // oyun ba�lad���nda can ful olucak
    }
    private void Update()
    {
        realScale = life / maxLife;
        
        if (transform.localScale.x > realScale) // burda can azal�cak
        {
            transform.localScale = new Vector3(transform.localScale.x - (transform.localScale.x - realScale) / reducespeed, transform.localScale.y, transform.localScale.z);
        }
        if (transform.localScale.x < realScale) // burda can yeniden dolucak
        {
            transform.localScale = new Vector3(transform.localScale.x + (realScale - transform.localScale.x) / reducespeed, transform.localScale.y, transform.localScale.z);
        }
        
       
        if (Input.GetKeyDown("a")&&life>0) //can�n bitmesini sa�lar.
        {
           
            life -= 10;
        }

       // if (life > 0)
        //{
          //  life -= realScale;
            //life = 0;
        //}


        if (Input.GetKeyDown("b") && life < maxLife) // can�n dolmas�n� sa�lar.
        {
            life += 5;
        }
        //if (life > maxLife)
       // {
           // life = maxLife;
       // }
    }


}
