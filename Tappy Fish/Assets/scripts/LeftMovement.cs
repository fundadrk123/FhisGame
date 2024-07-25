using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    public float speed;  // hýz deðiþkenidir.
    BoxCollider2D box; // boxcollider2d eriþip onunda box deðerini almak için.
    float roundWidth; // raound(zemin) boyutu için float deðiþkeni.
    float obstaclewidth; // obstacle(engel) boyutu için float deðiþkeni;
  
    // transform poistion nesneyi hareket etirmek için.

    


   void Start()
    {
        
        if (gameObject.CompareTag("Round")) // zemin için oluþturulmuþ kara yapýsý.
        {
         box = GetComponent<BoxCollider2D>();
         roundWidth = box.size.x; // box.size nýn x deðerini verdik.x yönüne geçe bilmesi için.
        }else if (gameObject.CompareTag("Obstacle")) // oyun nesenesi
        {
            obstaclewidth = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x; // obstaclewidth içerisine  x deðerini atayýp ama öncesinde column içersinden boxcollider2d nin içine eriþip size x deðerini alýyor.
        }
        
    }
 

   
    void Update()
    {
        if (GameManger.gameOver == false)  // gamemenger .gameover eþit olduðunda false ise transform postion al.
        {
            transform.position = new Vector2(transform.position.x -speed * Time.deltaTime, transform.position.y); // -speed deðerni verince float deðerini düþücek ve time.deltatime ile çarpýcak./speed deðiþkeni ni çaðýrmak için -speed olarak alýyoruz sola doðru gitmesi için ve transform ilede y pozisyonunu alýyoruz.
        }
        if (gameObject.CompareTag("Round"))
        {
            if (transform.position.x <= -roundWidth) //transform.position.x yönünden küçük yada eþit se rounwidth sola doðru git.
            {
                transform.position = new Vector2(transform.position.x + 2 * roundWidth, transform.position.y); // round'u 2 ile çarpýyor ki saðdan sola doðru gitmesi için.
            }
        }
        else if(gameObject.CompareTag("Obstacle")) // obstacle mý?
        {
            if (transform.position.x < GameManger.bottomLeft.x -obstaclewidth) // transform position x deðeri küçükse gamemanger.dan bottonlaefte eriþiyoruz.
            {
                Destroy(gameObject); // kapatýnca bütün engeller çoðalýyor.

            }
           
           
        }
        
    }
}
