using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    public float speed;  // h�z de�i�kenidir.
    BoxCollider2D box; // boxcollider2d eri�ip onunda box de�erini almak i�in.
    float roundWidth; // raound(zemin) boyutu i�in float de�i�keni.
    float obstaclewidth; // obstacle(engel) boyutu i�in float de�i�keni;
  
    // transform poistion nesneyi hareket etirmek i�in.

    


   void Start()
    {
        
        if (gameObject.CompareTag("Round")) // zemin i�in olu�turulmu� kara yap�s�.
        {
         box = GetComponent<BoxCollider2D>();
         roundWidth = box.size.x; // box.size n�n x de�erini verdik.x y�n�ne ge�e bilmesi i�in.
        }else if (gameObject.CompareTag("Obstacle")) // oyun nesenesi
        {
            obstaclewidth = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x; // obstaclewidth i�erisine  x de�erini atay�p ama �ncesinde column i�ersinden boxcollider2d nin i�ine eri�ip size x de�erini al�yor.
        }
        
    }
 

   
    void Update()
    {
        if (GameManger.gameOver == false)  // gamemenger .gameover e�it oldu�unda false ise transform postion al.
        {
            transform.position = new Vector2(transform.position.x -speed * Time.deltaTime, transform.position.y); // -speed de�erni verince float de�erini d���cek ve time.deltatime ile �arp�cak./speed de�i�keni ni �a��rmak i�in -speed olarak al�yoruz sola do�ru gitmesi i�in ve transform ilede y pozisyonunu al�yoruz.
        }
        if (gameObject.CompareTag("Round"))
        {
            if (transform.position.x <= -roundWidth) //transform.position.x y�n�nden k���k yada e�it se rounwidth sola do�ru git.
            {
                transform.position = new Vector2(transform.position.x + 2 * roundWidth, transform.position.y); // round'u 2 ile �arp�yor ki sa�dan sola do�ru gitmesi i�in.
            }
        }
        else if(gameObject.CompareTag("Obstacle")) // obstacle m�?
        {
            if (transform.position.x < GameManger.bottomLeft.x -obstaclewidth) // transform position x de�eri k���kse gamemanger.dan bottonlaefte eri�iyoruz.
            {
                Destroy(gameObject); // kapat�nca b�t�n engeller �o�al�yor.

            }
           
           
        }
        
    }
}
