using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacle; // obstacle engel deðiþkeni.rastgele engel atama baþarýlý.
    public GameObject[] newobstacle; //bunu sen ekledin.
    public GameObject[] newcoin;   // paralara eriþmek için.
    public GameObject[] deneme; 


    public float spwanInterval;// public GameObject[] newShark;
    public float maxTime; // float deðerinde maximum zaman.
    float timer; // zaman aralýðý için tanýmlanan deðiþken.
    public float maxY; // editör üzerinde deðiþtire bilirsin.
    public float minY;// editör üzerinden deðiþtire bilirsin.
    float randomY;// rastgele deðer.
    float randomX; // tam deðer belirlemek için.

    // Start is called before the first frame update
    void Start()
    {
       
       // InstantiateObstcle(); // engelimizi alabilmek için fonksiyonu bir kez çaðrýyoruz.bu bizim için belirlediðimiz konumlar içinde engel üretiyor.oyunu baþlatmadan engel üretiyor yorum satýrýndan alma!!!
    }


    // Update is called once per frame
    void Update()
    {
        if (GameManger.gameOver == false && GameManger.gameStarted==true) // false olduðu durumda çalýþ. / gamemanger.gamestarted==true olduðunda zamanlamayý baþlatsýn ve engelleri üretsin.
        {
            
            timer += Time.deltaTime; // zaman aralýðýný artýrdýk
            if (timer >= maxTime) // timer max zamandan büyük yada eþitse?
            {

                randomY = Random.Range(minY, maxY); // belirlediðimiz aralýk deðerleri için randomy deðerini çaðrýyoruz.

                InstantiateFish(); // balýk fonksiyonlarý
               InstantiateObstcle(); // fonksiyon çalýþtýktan sonra timer sýfýrlancak.ve üretecek.
                Instantiatecoin(); // para fonksiyonu
               // Instantiatecdeneme();
                timer = 0; // timer sýfýrlandý. ve 3,5 saniye sonra engel üretilmeye baþlanýcak.
                


            }
        }
    }
  
   public void InstantiateObstcle()// engellerimizi oluþturmak için.
    {
        GameObject newObstacle = Instantiate(obstacle[Random.Range(0, 3)]);
        newObstacle.transform.position = new Vector2(transform.position.x,randomY);// vector2 yi referans alýyoruz ve iki deðer istiyor ilk olarak x deðeri birde random y deðerini atýyor her engel çalýþtýkça random y atanacak.
    }

     public void InstantiateFish() // engellerimizi oluþturmak için.balýk engelleri.
     {
       GameObject newObstacle = Instantiate(newobstacle[Random.Range(0,4)]);  // balýðýn yerini random deðiþtirme.!
       newObstacle.transform.position = new Vector2(randomX,randomY); //random olarak atama yapar.

     }

    public void Instantiatecoin() // engellerimizi oluþturmak için. altýn para !!
    {
        //Debug.Log("collision" + GameManger.gameOver);

        GameObject newObstacle = Instantiate(newcoin[0]);  // balýðýn yerini random deðiþtirme.!
        newObstacle.transform.position = new Vector2(randomX, randomY); //random olarak atama yapar.

        
    }

  // public void Instantiatecdeneme() 
    //{
      //  GameObject newObstacle = Instantiate(deneme[0]);  
       // newObstacle.transform.position = new Vector2(randomX, randomY); 

   //}


}






